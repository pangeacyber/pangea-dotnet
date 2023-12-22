using PangeaCyber.Net;
using PangeaCyber.Net.Intel;
using PangeaCyber.Net.Exceptions;
using System.Resources;


class Program
{

    private static void PrintData(string indicator, IntelReputationData data)
    {
        Console.WriteLine($"\t Indicator: {indicator}");
        Console.WriteLine($"\t\t Verdict: {data.Verdict}");
        Console.WriteLine($"\t\t Score: {data.Score}");
        Console.WriteLine($"\t\t Category: {string.Join(", ", data.Category)}");
    }

    private static void PrintBulkData(DomainReputationBulkData data)
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
            var clientCfg = Config.FromEnvironment("domain-intel");

            // Create DomainIntelClient with builder
            DomainIntelClient client = new DomainIntelClient.Builder(clientCfg).Build();

            // Create request
            var req = new DomainReputationBulkRequest.Builder(new string[] {"pemewizubidob.cafij.co.za", "redbomb.com.tr", "kmbk8.hicp.net"})
                .WithProvider("domaintools")
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
