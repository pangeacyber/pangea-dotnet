using PangeaCyber.Net;
using PangeaCyber.Net.Intel;
using PangeaCyber.Net.Exceptions;


class Program
{
    private static void PrintData(string ip, IPProxyData data)
    {
        if (data.IsProxy)
        {
            Console.WriteLine($"\t IP {ip} is a proxy");
        }
        else
        {
            Console.WriteLine($"\t IP {ip} is not a proxy");
        }
    }

    private static void PrintBulkData(IPProxyBulkData data)
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
            var req = new IPProxyBulkRequest.Builder(new string[] { "34.201.32.172", "190.28.74.251" })
                .WithProvider("digitalelement")
                .WithVerbose(true)
                .WithRaw(true)
                .Build();

            // Send request
            var res = await client.IsProxyBulk(req);

            // If success, print result
            PrintBulkData(res.Result.Data);
        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine("Failed with exception: " + e.ToString());
        }
    }
}
