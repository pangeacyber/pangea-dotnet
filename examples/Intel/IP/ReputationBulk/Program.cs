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

    private static void PrintBulkData(IPReputationBulkData data)
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
            var clientCfg = Config.FromEnvironment("ip-intel");

            // Create IPIntelClient with builder
            IPIntelClient client = new IPIntelClient.Builder(clientCfg).Build();

            // Create request
            var req = new IPReputationBulkRequest.Builder(new string[]{"93.231.182.110", "190.28.74.251"})
                .WithProvider("crowdstrike")
                .WithVerbose(true)
                .WithRaw(true)
                .Build();

            // Send request
            var res = await client.ReputationBulk(req);

            // If success, print result
            Console.WriteLine("Success.");
            PrintBulkData(res.Result.Data);
        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine("Failed with exception: " + e.ToString());
        }
    }
}
