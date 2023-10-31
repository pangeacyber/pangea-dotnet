using PangeaCyber.Net.AuthN;
using PangeaCyber.Net.AuthN.Models;
using PangeaCyber.Net.AuthN.Requests;
using PangeaCyber.Net.AuthN.Results;
using PangeaCyber.Net.Exceptions;
using PangeaCyber.Net;

namespace PangeaCyber.Tests;

public static class Extentions
{
    public static void Merge<T, S>(this Dictionary<T, S> source, Dictionary<T, S> collection) where T : notnull
    {
        if (collection == null)
        {
            return;
        }

        foreach (var item in collection)
        {
            source[item.Key] = item.Value;
        }
    }
}

[TestCaseOrderer(
    "RunTestsInOrder.XUnit.AlphabeticalTestOrderer",
    "RunTestsInOrder.XUnit")]
public class ITAuthNTest
{
    static AuthNClient client = default!;
    Config cfg;
    TestEnvironment environment = TestEnvironment.LVE;
    private static Random random = new Random();
    private static readonly string randomValue = random.Next(10000000).ToString();
    private static readonly string emailTest = $"user.email+test{randomValue}@pangea.cloud";
    private static readonly string emailDelete = $"user.email+delete{randomValue}@pangea.cloud";
    private static readonly string emailInviteDelete = $"user.email+invite_del{randomValue}@pangea.cloud";
    private static readonly string emailInviteKeep = $"user.email+invite_keep{randomValue}@pangea.cloud";
    private static readonly string passwordOld = "My1s+Password";
    private static readonly string passwordNew = "My1s+Password_new";
    private static readonly string cbURI = "https://someurl.com/callbacklink";
    private static readonly Profile profileOld = new Profile("Name", "User");
    private static readonly Profile profileNew = new Profile
    {
        { "first_name", "NameUpdated" }
    };
    private static string userID = ""; // Will be set once the user is created

    public ITAuthNTest()
    {
        cfg = Config.FromIntegrationEnvironment(environment);
        client = new AuthNClient.Builder(cfg).Build();
    }

    [Fact]
    public async void TestCycle()
    {
        await TestA_UserActions(client);
        await TestB_ClientSessionList_n_Invalidate(client);
        await TestC_SessionList_n_Invalidate(client);
        await TestD_InviteActions(client);
        await TestE_ListUsers(client);
    }

    [Fact]
    public async Task TestAgreementsCycleEULA()
    {
        await AgreementsCycle(AgreementType.EULA);
    }

    [Fact]
    public async Task TestAgreementsCyclePP()
    {
        await AgreementsCycle(AgreementType.PrivacyPolicy);
    }

    private async Task AgreementsCycle(AgreementType type)
    {
        string name = $"{type}_{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}";
        string text = "This is agreement text";
        bool active = false;

        // Create agreement
        var createResponse = await client.Agreements.Create(
            new AgreementCreateRequest.Builder(type, name, text).WithActive(active).Build());
        Assert.Equal(name, createResponse.Result.Name);
        Assert.Equal(text, createResponse.Result.Text);
        Assert.Equal(active, createResponse.Result.Active);
        string id = createResponse.Result.ID;
        Assert.NotNull(id);

        // Update agreement
        string new_name = $"{name}_v2";
        string new_text = $"{text} v2";

        var updateResponse = await client.Agreements.Update(
            new AgreementUpdateRequest.Builder(type, id)
                .WithName(new_name)
                .WithText(new_text)
                .WithActive(active)
                .Build());
        Assert.Equal(new_name, updateResponse.Result.Name);
        Assert.Equal(new_text, updateResponse.Result.Text);
        Assert.Equal(active, updateResponse.Result.Active);

        var filter = new FilterAgreementList();

        // List
        var listResponse = await client.Agreements.List(new AgreementListRequest.Builder().WithFilter(filter).Build());
        Assert.True(listResponse.Result.Count > 0);
        Assert.True(listResponse.Result.Agreements.Length > 0);
        int count = listResponse.Result.Count;

        // Delete
        var deleteResponse = await client.Agreements.Delete(new AgreementDeleteRequest.Builder(type, id).Build());

        // List again
        var listResponseAfterDelete = await client.Agreements.List(new AgreementListRequest.Builder().WithFilter(filter).Build());
        Assert.Equal(count - 1, listResponseAfterDelete.Result.Count);
    }

    private static async Task<FlowUpdateResult> FlowHandlePasswordPhase(string flowID, string password)
    {
        var response = await client.Flow
            .Update(new FlowUpdateRequest.Builder(flowID, FlowChoice.PASSWORD,
                new FlowUpdateDataPassword.Builder(password).Build()).Build());
        return response.Result;
    }

    private static async Task<FlowUpdateResult> FlowHandleProfilePhase(string flowID)
    {
        var response = await client.Flow
            .Update(new FlowUpdateRequest.Builder(flowID, FlowChoice.PROFILE,
                new FlowUpdateDataProfile.Builder(profileOld).Build()).Build());
        return response.Result;
    }

    private static async Task<FlowUpdateResult> FlowHandleAgreementsPhase(string flowID, FlowUpdateResult result)
    {
        // Iterate over flow_choices in response.result
        List<string> agreed = new List<string>();
        if (result.FlowChoices != null)
        {
            foreach (var flowChoiceItem in result.FlowChoices)
            {
                if (flowChoiceItem.Choice == FlowChoice.AGREEMENTS.ToString() && flowChoiceItem.Data != null)
                {
                    if (flowChoiceItem.Data.TryGetValue("agreements", out var agreementsObj) && agreementsObj is Dictionary<string, object> agreements)
                    {
                        // Iterate over agreements and append the "id" values to agreed list
                        foreach (var agreementObj in agreements.Values)
                        {
                            if (agreementObj is Dictionary<string, object> agreement && agreement.TryGetValue("id", out var idObj) && idObj is string id)
                            {
                                agreed.Add(id);
                            }
                        }
                    }
                }
            }
        }

        var response = await client.Flow.Update(
            new FlowUpdateRequest.Builder(flowID, FlowChoice.AGREEMENTS,
                new FlowUpdateDataAgreements.Builder(agreed).Build())
                .Build());

        return response.Result;
    }

    private static bool ChoiceIsAvailable(FlowChoiceItem[] choices, string choice)
    {
        return choices.Any(flowChoiceItem => flowChoiceItem.Choice.Equals(choice, StringComparison.OrdinalIgnoreCase));
    }

    private static async Task<FlowCompleteResult> CreateAndLogin(string email, string password)
    {
        FlowType[] flowTypes = { FlowType.Signup, FlowType.Signin };
        var startResponse = await client.Flow.Start(new FlowStartRequest.Builder()
            .WithEmail(email)
            .WithFlowType(flowTypes)
            .WithCBUri(cbURI)
            .Build());

        string flowID = startResponse.Result.FlowID;
        FlowUpdateResult? result = null;
        string flowPhase = "initial";
        var choices = startResponse.Result.FlowChoices;

        while (flowPhase != null && !flowPhase.Equals("phase_completed", StringComparison.OrdinalIgnoreCase) && choices != null)
        {
            if (ChoiceIsAvailable(choices, FlowChoice.PASSWORD.ToString()))
            {
                result = await FlowHandlePasswordPhase(flowID, password);
            }
            else if (ChoiceIsAvailable(choices, FlowChoice.PROFILE.ToString()))
            {
                result = await FlowHandleProfilePhase(flowID);
            }
            else if (ChoiceIsAvailable(choices, FlowChoice.AGREEMENTS.ToString()) && result != null)
            {
                result = await FlowHandleAgreementsPhase(flowID, result);
            }
            else
            {
                if (result != null)
                {
                    Console.WriteLine($"Phase {result.FlowPhase} not handled");
                    throw new PangeaException("Phase not handled", null);
                }
                else
                {
                    Console.WriteLine("Result is null");
                    throw new PangeaException("Result is null", null);
                }
            }

            if (result != null)
            {
                flowPhase = (result.FlowPhase != null) ? result.FlowPhase : "phase_completed";
                choices = result.FlowChoices;
            }
            else
            {
                throw new PangeaException("Result is null", null);
            }
        }

        var response = await client.Flow.Complete(flowID);
        return response.Result;
    }

    private static async Task<FlowCompleteResult> Login(string email, string password)
    {
        FlowType[] flowTypes = { FlowType.Signin };
        var startResponse = await client.Flow.Start(new FlowStartRequest.Builder()
            .WithEmail(email)
            .WithFlowType(flowTypes)
            .WithCBUri(cbURI)
            .Build());

        string flowID = startResponse.Result.FlowID;

        await client.Flow.Update(new FlowUpdateRequest.Builder(
            flowID,
            FlowChoice.PASSWORD,
            new FlowUpdateDataPassword.Builder(password).Build())
            .Build());

        var response = await client.Flow.Complete(flowID);
        return response.Result;
    }

    private static async Task TestA_UserActions(AuthNClient client)
    {
        try
        {
            // Create User 1
            var createResp1 = await CreateAndLogin(emailTest, passwordOld);

            // Create user 2
            var createResp2 = await CreateAndLogin(emailDelete, passwordOld);

            // Get profile by email. Should be empty because it was created without profile parameter
            var profileGetResp = await client.User.Profile.GetByEmail(emailDelete);
            Assert.True(profileGetResp.IsOK);
            Assert.NotNull(profileGetResp.Result);
            Assert.Equal(emailDelete, profileGetResp.Result.Email);
            Assert.Equal(profileOld, profileGetResp.Result.Profile);

            // Logout (delete user)
            var logoutResp = await client.Session.Logout(profileGetResp.Result.ID);
            Assert.True(logoutResp.IsOK);

            // Delete user (delete user)
            var deleteResp1 = await client.User.DeleteByEmail(emailDelete);
            Assert.True(deleteResp1.IsOK);
            Assert.Null(deleteResp1.Result);

            // Token check
            string token = createResp1.ActiveToken != null ? createResp1.ActiveToken.Token : "";
            var checkResp = await client
                .Client
                .Token
                .Check(token);
            Assert.True(checkResp.IsOK);

            // Update password
            var passUpdateResp = await client
                .Client
                .Password
                .Change(token, passwordOld, passwordNew);
            Assert.True(passUpdateResp.IsOK);
            Assert.Null(passUpdateResp.Result);

            // Update profile
            // Get profile by email. Should be empty because it was created without profile parameter
            profileGetResp = await client.User.Profile.GetByEmail(emailTest);
            Assert.True(profileGetResp.IsOK);
            Assert.NotNull(profileGetResp.Result);
            userID = profileGetResp.Result.ID;
            Assert.Equal(emailTest, profileGetResp.Result.Email);
            Assert.Equal(profileOld, profileGetResp.Result.Profile);

            // Get by ID
            profileGetResp = await client.User.Profile.GetByID(userID);
            Assert.True(profileGetResp.IsOK);
            Assert.NotNull(profileGetResp.Result);
            Assert.Equal(userID, profileGetResp.Result.ID);
            Assert.Equal(emailTest, profileGetResp.Result.Email);
            Assert.Equal(profileOld, profileGetResp.Result.Profile);

            // Add one new field to profile
            var profileUpdateResp = await client.User.Profile.Update(
                new UserProfileUpdateRequest.Builder(profileNew).WithID(userID).Build()
            );
            Assert.True(profileUpdateResp.IsOK);
            Assert.NotNull(profileUpdateResp.Result);
            Assert.Equal(userID, profileUpdateResp.Result.ID);
            Assert.Equal(emailTest, profileUpdateResp.Result.Email);
            Profile finalProfile = new Profile();
            Extentions.Merge(finalProfile, profileOld);
            Extentions.Merge(finalProfile, profileNew);
            Assert.Equal(finalProfile, profileUpdateResp.Result.Profile);

            // User update
            var userUpdateResp = await client.User.Update(
                new UserUpdateRequest.Builder().WithEmail(emailTest).WithDisabled(false).Build()
            );
            Assert.True(userUpdateResp.IsOK);
            Assert.Equal(userID, userUpdateResp.Result.ID);
            Assert.Equal(emailTest, userUpdateResp.Result.Email);
            Assert.False(userUpdateResp.Result.Disabled);

            // Client session refresh (refresh and active token)
            var refreshResp = await client.Client.Session.Refresh(
                new ClientSessionRefreshRequest.Builder(
                    createResp1.RefreshToken.Token
                ).WithUserToken(token)
                .Build()
            );
            Assert.True(refreshResp.IsOK);
            Assert.NotNull(refreshResp.Result.ActiveToken);
            Assert.NotNull(refreshResp.Result.RefreshToken);

            // Client session refresh (only refresh token)
            refreshResp = await client.Client.Session.Refresh(
                new ClientSessionRefreshRequest.Builder(
                    refreshResp.Result.RefreshToken.Token
                )
                .Build()
            );
            Assert.True(refreshResp.IsOK);
            Assert.NotNull(refreshResp.Result.ActiveToken);
            Assert.NotNull(refreshResp.Result.RefreshToken);

            // Client session logout
            var logoutResp2 = await client.Client.Session.Logout(
                refreshResp.Result.ActiveToken.Token
            );
            Assert.True(logoutResp2.IsOK);
        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine(e.ToString());
            Assert.True(false);
        }
    }

    private static async Task TestB_ClientSessionList_n_Invalidate(AuthNClient client)
    {
        try
        {
            // User login
            var loginResp = await Login(emailTest, passwordNew);
            Assert.NotNull(loginResp.ActiveToken);
            Assert.NotNull(loginResp.RefreshToken);
            string token = loginResp.ActiveToken.Token;

            // List client sessions
            var filter = new FilterSessionList();
            var listResp = await client.Client.Session.List(new ClientSessionListRequest.Builder(token).WithFilter(filter).Build());
            Assert.True(listResp.IsOK);
            Assert.True(listResp.Result.Sessions.Length > 0);

            foreach (var session in listResp.Result.Sessions)
            {
                try
                {
                    // Invalidate client sessions
                    var invalidateResp = await client.Client.Session.Invalidate(token, session.ID);
                    Assert.True(invalidateResp.IsOK);
                }
                catch (PangeaAPIException e)
                {
                    Console.WriteLine($"Failed to invalidate session_id[{session.ID}] token[{token}]");
                    Console.WriteLine(e.ToString());
                }
            }
        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine(e.ToString());
            Assert.True(false);
        }
    }

    private static async Task TestC_SessionList_n_Invalidate(AuthNClient client)
    {
        try
        {
            // User login
            var loginResp = await Login(emailTest, passwordNew);
            Assert.NotNull(loginResp.ActiveToken);
            Assert.NotNull(loginResp.RefreshToken);
            string token = loginResp.ActiveToken.Token;

            // Session list
            var filter = new FilterSessionList();
            var listResp = await client.Session.List(new SessionListRequest.Builder().WithFilter(filter).Build());
            Assert.True(listResp.IsOK);
            Assert.True(listResp.Result.Sessions.Length > 0);

            foreach (var session in listResp.Result.Sessions)
            {
                try
                {
                    // invalidate sessions
                    var invalidateResp = await client.Session.Invalidate(session.ID);
                    Assert.True(invalidateResp.IsOK);
                }
                catch (PangeaAPIException e)
                {
                    Console.WriteLine($"Failed to invalidate session_id[{session.ID}] token[{token}]");
                    Console.WriteLine(e.ToString());
                }
            }
        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine(e.ToString());
            Assert.True(false);
        }
    }

    private static async Task TestD_InviteActions(AuthNClient client)
    {
        try
        {
            // Invite 1
            var inviteResp1 = await client.User.Invite(
                new UserInviteRequest.Builder(
                    emailTest,
                    emailInviteKeep,
                    "https://someurl.com/callbacklink",
                    "somestate"
                )
                .Build()
            );
            Assert.True(inviteResp1.IsOK);
            Assert.NotNull(inviteResp1.Result);
        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine(e.ToString());
            Assert.True(false);
        }

        Response<UserInviteResult>? inviteResp2 = null;
        try
        {
            // Invite 2
            inviteResp2 = await client.User.Invite(
                new UserInviteRequest.Builder(
                    emailTest,
                    emailInviteDelete,
                    "https://someurl.com/callbacklink",
                    "somestate"
                )
                .Build()
            );
            Assert.True(inviteResp2.IsOK);
            Assert.NotNull(inviteResp2.Result);
        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine(e.ToString());
            Assert.True(false);
        }

        try
        {
            // Delete invite
            var deleteResp = await client.User.Invites.Delete(inviteResp2.Result.ID);
            Assert.True(deleteResp.IsOK);
        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine(e.ToString());
            Assert.True(false);
        }

        try
        {
            // List users invites
            var filter = new FilterUserInviteList();
            var inviteListResp1 = await client.User.Invites.List(new UserInviteListRequest.Builder().WithFilter(filter).Build());
            Assert.True(inviteListResp1.IsOK);
            Assert.NotNull(inviteListResp1.Result.Invites);
            Assert.True(inviteListResp1.Result.Invites.Length > 0);

            foreach (var userInvite in inviteListResp1.Result.Invites)
            {
                // Delete invite
                var deleteResp = await client.User.Invites.Delete(userInvite.ID);
                Assert.True(deleteResp.IsOK);
            }
        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine(e.ToString());
            Assert.True(false);
        }
    }

    private static async Task TestE_ListUsers(AuthNClient client)
    {
        try
        {
            var filter = new FilterUserList();
            var userListResp1 = await client.User.List(new UserListRequest.Builder().WithFilter(filter).Build());
            Assert.True(userListResp1.IsOK);
            Assert.True(userListResp1.Result.Users.Length > 0);

            foreach (var user in userListResp1.Result.Users)
            {
                try
                {
                    var deleteResp = await client.User.DeleteByID(user.ID);
                    Assert.True(deleteResp.IsOK);
                }
                catch (PangeaAPIException e)
                {
                    Console.WriteLine($"Failed to delete user ID: {user.ID}\n");
                    Console.WriteLine(e.ToString());
                }
            }
        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine(e.ToString());
            Assert.True(false);
        }
    }
}
