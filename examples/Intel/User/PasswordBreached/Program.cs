using PangeaCyber.Net;
using PangeaCyber.Net.Intel;
using PangeaCyber.Net.Exceptions;
using System.Text;
using System.Security.Cryptography;


class Program
{

    static async Task Main(string[] args)
    {
        try
        {
            // Load client config. Can create it manually with Config constructor and setters
            var clientCfg = Config.FromEnvironment("user-intel");

            // Create client with builder
            UserIntelClient client = new UserIntelClient.Builder(clientCfg).Build();

            // Set the password you would like to check
            string password = "mypassword";

            // Calculate its hash, it could be sha256 or sha1
            string hash = Utils.GetSHA256Hash(password);

            // get the hash prefix, right now it should be just 5 characters
            string hashPrefix = Utils.GetHashPrefix(hash, 5);

            Response<UserPasswordBreachedResult>? response = null;

            try
            {
                response = await client.Breached(new UserPasswordBreachedRequest.Builder(HashType.SHA256, hashPrefix)
                    .WithVerbose(true)
                    .WithRaw(true)
                    .Build());
            }
            catch (Exception e)
            {
                Console.WriteLine("Fail to perform request: " + e);
                Environment.Exit(1);
            }

            Console.WriteLine("Request success");
            Console.WriteLine("User password found in breach?: " + response.Result.Data.FoundInBreach);
            Console.WriteLine($"Found in {response.Result.Data.BreachCount} breachs");

            // This auxiliary function analyze service provider raw data to search for full hash in their registers
            PasswordStatus status = UserIntelClient.IsPasswordBreached(response.Result, hash);
            if (status == PasswordStatus.Breached)
            {
                Console.WriteLine($"Password '{password}' has been breached");
            }
            else if (status == PasswordStatus.Unbreached)
            {
                Console.WriteLine($"Password '{password}' has not been breached");
            }
            else if (status == PasswordStatus.Inconclusive)
            {
                Console.WriteLine($"Not enough information to confirm if password '{password}' has been or has not been breached.");
            }
            else
            {
                Console.WriteLine($"Unknown status: {status}");
            }

        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine("Failed with exception: " + e.ToString());
        }
    }
}
