using Newtonsoft.Json;
using PangeaCyber.Net;
using PangeaCyber.Net.AuthN;
using PangeaCyber.Net.AuthN.Models;
using PangeaCyber.Net.AuthN.Requests;
using PangeaCyber.Net.AuthN.Results;
using PangeaCyber.Net.Exceptions;

static class Program
{
    private static Random random = new Random();
    private static string randomValue = random.Next(10000000).ToString();
    private static string userEmail = $"user.email+test{randomValue}@pangea.cloud";
    private static string passwordInitial = "My1s+Password";
    private static string passwordNew = "My1s+Password_new";
    private static Profile profileInitial = new Profile();
    private static Profile profileUpdate = new Profile();
    private static string userID = ""; // Will be set once the user is created
    private static string cbURI = "https://someurl.com/callbacklink";
    private static AuthNClient client = null!;

    private static async Task<FlowUpdateResult> FlowHandlePasswordPhase(string flowID, string password)
    {
        var response = await client.Flow.Update(
            new FlowUpdateRequest.Builder(
                flowID,
                FlowChoice.PASSWORD,
                new FlowUpdateDataPassword.Builder(password).Build()
            ).Build()
        );
        return response.Result;
    }
    private static async Task<FlowUpdateResult> FlowHandleProfilePhase(string flowID)
    {
        var response = await client.Flow.Update(
            new FlowUpdateRequest.Builder(
                flowID,
                FlowChoice.PROFILE,
                new FlowUpdateDataProfile.Builder(profileInitial).Build()
            ).Build()
        );
        return response.Result;
    }

    private static async Task<FlowUpdateResult> FlowHandleAgreementsPhase(string flowID, FlowUpdateResult result)
    {
        List<string> agreed = new List<string>();
        foreach (FlowChoiceItem flowChoiceItem in result.FlowChoices!)
        {
            if (string.Equals(flowChoiceItem.Choice, nameof(FlowChoice.AGREEMENTS), StringComparison.OrdinalIgnoreCase))
            {
                var agreements = JsonConvert.DeserializeObject<Dictionary<string, object>>(
                    flowChoiceItem.Data!["agreements"].ToString()!
                );
                if (agreements != null)
                {
                    // Iterate over agreements and append the "id" values to agreed list
                    foreach (object agreementObj in agreements.Values)
                    {
                        var agreementItem = JsonConvert.DeserializeObject<Dictionary<string, object>>(
                            agreementObj.ToString()!
                        );
                        var idObj = agreementItem!["id"];
                        if (idObj is string)
                        {
                            agreed.Add((string)idObj);
                        }
                    }
                }
            }
        }

        Console.WriteLine("Agreed: ");
        Console.WriteLine(string.Join(", ", agreed));

        var response = await client.Flow.Update(
            new FlowUpdateRequest.Builder(
                flowID,
                FlowChoice.AGREEMENTS,
                new FlowUpdateDataAgreements.Builder(agreed).Build()
            ).Build()
        );
        return response.Result;
    }

    private static bool ChoiceIsAvailable(FlowChoiceItem[] choices, string choice)
    {
        foreach (FlowChoiceItem flowChoiceItem in choices)
        {
            if (string.Equals(flowChoiceItem.Choice, choice, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }

    private static async Task<FlowCompleteResult> UserCreateAndLogin(string email, string password)
    {
        FlowType[] flowTypes = { FlowType.Signup, FlowType.Signin };
        var startResponse = await client.Flow
            .Start(new FlowStartRequest.Builder().WithEmail(email).WithFlowType(flowTypes).WithCBUri(cbURI).Build());

        string flowID = startResponse.Result.FlowID;
        FlowUpdateResult? result = null;
        string flowPhase = "initial";
        var choices = startResponse.Result.FlowChoices ?? Array.Empty<FlowChoiceItem>();

        while (flowPhase != "phase_completed")
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
                Console.WriteLine($"Phase {result!.FlowPhase} not handled");
                throw new PangeaException("Phase not handled", null);
            }

            flowPhase = result.FlowPhase!;
            choices = result.FlowChoices ?? Array.Empty<FlowChoiceItem>();
        }

        var response = await client.Flow.Complete(flowID);
        return response.Result;
    }

    static async Task Main(string[] args)
    {
        try
        {
            // Load client config. Can create it manually with Config constructor and setters
            var cfg = Config.FromEnvironment("authn");

            // Create client with builder
            client = new AuthNClient.Builder(cfg).Build();

            profileInitial["first_name"] = "Name";
            profileInitial["last_name"] = "User";
            profileUpdate["first_name"] = "NameUpdated";

            // Create User 1
            Console.WriteLine("Creating user...");
            var createResp1 = await UserCreateAndLogin(userEmail, passwordInitial);
            Console.WriteLine("User create success.");

            // Update password
            Console.WriteLine("Update user password...");
            var passUpdateResp = await client.Client.Password.Change(
                createResp1.ActiveToken?.Token!, passwordInitial, passwordNew
            );
            Console.WriteLine("Update password success.");

            // Update profile
            Console.WriteLine("Get profile by email...");
            // Get profile by email. Should be empty because it was created without profile parameter
            var profileGetResp = await client.User.Profile.GetByEmail(userEmail);
            userID = profileGetResp.Result.ID ?? default!;
            Console.WriteLine("Get profile success.");

            Console.WriteLine("Get profile by ID...");
            profileGetResp = await client.User.Profile.GetByID(userID);
            Console.WriteLine("Get profile success.");

            Console.WriteLine("Update profile...");
            // Update profile
            // Add one new field to the profile
            var profileUpdateResp = await client.User.Profile.Update(
                new UserProfileUpdateRequest.Builder(profileInitial).WithEmail(userEmail).Build()
            );
            Console.WriteLine("Update profile success.");

            // User update
            Console.WriteLine("User update...");
            var userUpdateResp = await client.User.Update(
                new UserUpdateRequest.Builder().WithEmail(userEmail).WithDisabled(false).Build()
            );
            Console.WriteLine("Update user success.");

            // List users
            Console.WriteLine("Listing users...");
            var userListResp1 = await client.User.List(new UserListRequest.Builder().Build());
            Console.WriteLine($"There are {userListResp1.Result.Count} users.");

            // Delete user
            Console.WriteLine("Deleting user...");
            var deleteResp1 = await client.User.DeleteByEmail(userEmail);
            Console.WriteLine("User delete success");

            // List users
            Console.WriteLine("Listing users...");
            userListResp1 = await client.User.List(new UserListRequest.Builder().Build());
            Console.WriteLine($"There are {userListResp1.Result.Count} users.");

            Console.WriteLine("Success!");
        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine("Failed with exception: " + e);
        }
    }
}
