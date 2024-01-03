using PangeaCyber.Net;
using PangeaCyber.Net.Intel;
using PangeaCyber.Net.Exceptions;


class Program
{

    static async Task Main(string[] args)
    {
        try
        {
            // Load client config. Can create it manually with Config constructor and setters
            var clientCfg = Config.FromEnvironment("url-intel");

            // Create URLIntelClient with builder
            URLIntelClient client = new URLIntelClient.Builder(clientCfg).Build();

            // Create request
            var req = new URLReputationRequest.Builder("http://113.235.101.11:54384")
                .WithProvider("crowdstrike")
                .WithVerbose(true)
                .WithRaw(true)
                .Build();

            // Send request
            var res = await client.Reputation(req);

            // If success, print result
            Console.WriteLine($"Success. Verdict: {res.Result.Data.Verdict}");
            if (res.Result.RawData != null)
            {
                Console.WriteLine("Raw provider data:");
                foreach (KeyValuePair<string, object> kvp in res.Result.RawData)
                {
                    Console.WriteLine("\"{0}\": {1}", kvp.Key, kvp.Value);
                }
            }
        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine("Failed with exception: " + e.ToString());
        }
    }
}
