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
            var req = new IPGeolocateRequest.Builder("93.231.182.110")
                .WithProvider("digitalelement")
                .WithVerbose(true)
                .WithRaw(true)
                .Build();

            // Send request
            var res = await client.Geolocate(req);

            // If success, print result
            Console.WriteLine($"Success. Country: {res.Result.Data.Country}");
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
