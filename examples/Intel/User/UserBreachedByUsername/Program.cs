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

            var response = await client.Breached(new UserBreachedRequest.Builder()
                .WithUsername("shortpatrick")
                .WithVerbose(true)
                .WithRaw(true)
                .Build());

            Console.WriteLine("Request success");
            Console.WriteLine("User found in breach?: " + response.Result.Data.FoundInBreach);
            Console.WriteLine($"Found in {response.Result.Data.BreachCount} breachs");

        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine("Failed with exception: " + e.ToString());
        }
    }
}
