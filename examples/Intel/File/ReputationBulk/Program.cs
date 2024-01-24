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

    private static void PrintBulkData(FileReputationBulkData data)
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
            var clientCfg = Config.FromEnvironment("file-intel");

            // Create FileIntelClient with builder
            FileIntelClient client = new FileIntelClient.Builder(clientCfg).Build();

            // Create request
            var req = new FileHashReputationBulkRequest.Builder(
                new string[] {
                    "142b638c6a60b60c7f9928da4fb85a5a8e1422a9ffdc9ee49e17e56ccca9cf6e",
                    "179e2b8a4162372cd9344b81793cbf74a9513a002eda3324e6331243f3137a63"
                    }, "sha256")
                .WithProvider("reversinglabs")
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
