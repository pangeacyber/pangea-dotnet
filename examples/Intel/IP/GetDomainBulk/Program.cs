using PangeaCyber.Net;
using PangeaCyber.Net.Intel;
using PangeaCyber.Net.Exceptions;


class Program
{
    public static void PrintData(string ip, IPDomainData data)
    {
        if (data.DomainFound)
        {
            Console.WriteLine($"\t IP {ip} domain is {data.Domain}");
        }
        else
        {
            Console.WriteLine($"\t IP {ip} domain not found");
        }
    }

    private static void PrintBulkData(IPDomainBulkData data)
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
            var req = new IPDomainBulkRequest.Builder(new string[] { "93.231.182.110", "190.28.74.251" })
                .WithProvider("digitalelement")
                .WithVerbose(true)
                .WithRaw(true)
                .Build();

            // Send request
            var res = await client.GetDomainBulk(req);

            // If success, print result
            PrintBulkData(res.Result.Data);
        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine("Failed with exception: " + e.ToString());
        }
    }
}
