using PangeaCyber.Net;
using PangeaCyber.Net.Intel;
using PangeaCyber.Net.Exceptions;
using System;


class Program
{

    private static void PrintData(string ip, IPVPNData data)
    {
        if (data.IsVPN)
        {
            Console.WriteLine($"\t IP {ip} is a VPN");
        }
        else
        {
            Console.WriteLine($"\t IP {ip} is not a VPN");
        }
    }

    private static void PrintBulkData(IPVPNBulkData data)
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
            var req = new IPVPNBulkRequest.Builder(new string[] {"2.56.189.74", "190.28.74.251"})
                .WithProvider("digitalelement")
                .WithVerbose(true)
                .WithRaw(true)
                .Build();

            // Send request
            var res = await client.IsVPNBulk(req);

            // If success, print result
            PrintBulkData(res.Result.Data);
        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine("Failed with exception: " + e.ToString());
        }
    }
}
