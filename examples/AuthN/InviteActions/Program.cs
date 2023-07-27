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
    private static string emailInviteDelete = $"user.email+invite_del{randomValue}@pangea.cloud";
    private static string emailInviteKeep = $"user.email+invite_keep{randomValue}@pangea.cloud";

    static async Task Main(string[] args)
    {
        // Audit sample
        try
        {
            // Load client config. Can create it manually with Config constructor and setters
            var cfg = Config.FromEnvironment("authn");

            // Create client with builder
            AuthNClient client = new AuthNClient.Builder(cfg).Build();

            // Invite 1
            Console.WriteLine("Invite user 1...");
            var inviteResp1 = await client.User.Invite(
                new UserInviteRequest.Builder(
                    userEmail,
                    emailInviteKeep,
                    "https://www.usgs.gov/faqs/what-was-pangea",
                    "somestate")
                .Build()
            );
            Console.WriteLine("Invite ID: " + inviteResp1.Result.ID);

            // Invite 2
            Console.WriteLine("Invite user 2...");
            var inviteResp2 = await client.User.Invite(
                new UserInviteRequest.Builder(
                    userEmail,
                    emailInviteDelete,
                    "https://www.usgs.gov/faqs/what-was-pangea",
                    "somestate")
                .Build()
            );
            Console.WriteLine("Invite ID: " + inviteResp2.Result.ID);

            // List invites
            Console.WriteLine("List invites...");
            var inviteListResp1 = await client.User.Invites.List(
                new UserInviteListRequest.Builder().Build()
            );
            Console.WriteLine($"There are {inviteListResp1.Result.Count} invites.");

            // Delete invite
            Console.WriteLine("Delete invite...");
            var deleteResp = client.User.Invites.Delete(inviteResp2.Result.ID);
            Console.WriteLine("Delete invite success.");

            // List invites
            Console.WriteLine("List invites...");
            inviteListResp1 = await client.User.Invites.List(
                new UserInviteListRequest.Builder().Build()
            );
            Console.WriteLine($"There are {inviteListResp1.Result.Count} invites.");

            Console.WriteLine("Success!");
        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine("Failed with exception: " + e.ToString());
        }
    }
}
