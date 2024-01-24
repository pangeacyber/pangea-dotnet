using PangeaCyber.Net;
using PangeaCyber.Net.Intel;
using PangeaCyber.Net.Exceptions;


class Program
{

    private static void PrintData(string indicator, IntelReputationData data)
    {
        Console.WriteLine($"\t Indicator: {indicator}");
        Console.WriteLine($"\t\t Verdict: {data.Verdict}");
        Console.WriteLine($"\t\t Score: {data.Score}");
        Console.WriteLine($"\t\t Category: {string.Join(", ", data.Category)}");
    }

    private static void PrintBulkData(URLReputationBulkData data)
    {
        foreach (var entry in data)
        {
            PrintData(entry.Key, entry.Value);
        }
    }

    static async Task Main(string[] args)
    {
        try
        {
            // Load client config. Can create it manually with Config constructor and setters
            var clientCfg = Config.FromEnvironment("url-intel");

            // Create URLIntelClient with builder
            URLIntelClient client = new URLIntelClient.Builder(clientCfg).Build();

            // Create request
            var req = new URLReputationBulkRequest.Builder(new string[] { "http://113.235.101.11:54384" })
                .WithProvider("crowdstrike")
                .WithVerbose(true)
                .WithRaw(true)
                .Build();

            // Send request
            var res = await client.ReputationBulk(req);

            // If success, print result
            Console.WriteLine($"Success.");
            PrintBulkData(res.Result.Data);
        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine("Failed with exception: " + e.ToString());
        }
    }
}
