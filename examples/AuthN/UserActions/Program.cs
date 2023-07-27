using PangeaCyber.Net;
using PangeaCyber.Net.Exceptions;
using PangeaCyber.Net.AuthN;
using PangeaCyber.Net.AuthN.Models;
using PangeaCyber.Net.AuthN.Requests;

class Program
{

    private static Random random = new Random();
    private static string randomValue = random.Next(10000000).ToString();
    private static string userEmail = $"user.email+test{randomValue}@pangea.cloud";
    private static string passwordInitial = "My1s+Password";
    private static string passwordNew = "My1s+Password_new";
    private static Profile profileInitial = new Profile();
    private static Profile profileUpdate = new Profile();
    private static string userID = ""; // Will be set once the user is created


    static async Task Main(string[] args)
    {
        try
        {
            // Load client config. Can create it manually with Config constructor and setters
            var cfg = Config.FromEnvironment("authn");

            // Create client with builder
            AuthNClient client = new AuthNClient.Builder(cfg).Build();

            profileInitial["name"] = "User name";
            profileInitial["country"] = "Argentina";
            profileUpdate["age"] = "18";

           // Create User 1
            Console.WriteLine("Creating user...");
            var createResp1 = await client.User.Create(
                new UserCreateRequest.Builder(userEmail, passwordInitial, IDProvider.Password)
                .WithProfile(profileInitial)
                .Build()
            );
            userID = createResp1.Result.ID ?? default!;
            Console.WriteLine("User create success. ID: " + userID);

            // User login
            Console.WriteLine("Login user...");
            var loginResp = await client.User.Login.Password(userEmail, passwordInitial);
            Console.WriteLine("Login user success. Token: " + loginResp.Result.ActiveToken?.Token);

            // Update password
            Console.WriteLine("Update user password...");
            var passUpdateResp = await client.Client.Password.Change(
                loginResp.Result.ActiveToken?.Token, passwordInitial, passwordNew
            );
            Console.WriteLine("Update password success.");

            // Update profile
            Console.WriteLine("Get profile by email...");
            // Get profile by email. Should be empty because it was created without profile parameter
            var profileGetResp = await client.User.Profile.GetByEmail(userEmail);
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
                new UserUpdateRequest.Builder().WithEmail(userEmail).WithDisabled(false).WithRequireMFA(false).Build()
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
            Console.WriteLine("Failed with exception: " + e.ToString());
        }
    }
}
