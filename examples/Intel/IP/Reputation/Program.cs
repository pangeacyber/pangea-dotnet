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
            var clientCfg = Config.FromEnvironment("ip-intel");

            // Create IPIntelClient with builder
            IPIntelClient client = new IPIntelClient.Builder(clientCfg).Build();

            // Create request
            var req = new IPReputationRequest.Builder("93.231.182.110")
                .WithProvider("crowdstrike")
                .WithVerbose(true)
                .WithRaw(true)
                .Build();

            // Send request
            var res = await client.Reputation(req);

            // If success, print result
            Console.WriteLine($"Success. Verdict: {res.Result.Data.Verdict}");
            if( res.Result.RawData != null ) {
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
