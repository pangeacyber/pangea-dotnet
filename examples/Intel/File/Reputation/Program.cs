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
            var clientCfg = Config.FromEnvironment("file-intel");

            // Create FileIntelClient with builder
            FileIntelClient client = new FileIntelClient.Builder(clientCfg).Build();

            // Create request
            var req = new FileHashReputationRequest.Builder("142b638c6a60b60c7f9928da4fb85a5a8e1422a9ffdc9ee49e17e56ccca9cf6e", "sha256")
                .WithProvider("reversinglabs")
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
