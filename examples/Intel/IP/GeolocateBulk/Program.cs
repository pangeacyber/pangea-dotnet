using PangeaCyber.Net;
using PangeaCyber.Net.Intel;
using PangeaCyber.Net.Exceptions;
using System;


class Program
{

    public static void PrintData(string indicator, IPGeolocateData data)
    {
        Console.WriteLine($"\t Indicator: {indicator}");
        Console.WriteLine($"\t\t Country: {data.Country}");
        Console.WriteLine($"\t\t City: {data.City}");
        Console.WriteLine($"\t\t Latitud: {data.Latitude}");
        Console.WriteLine($"\t\t Longitud: {data.Longitude}");
        Console.WriteLine($"\t\t Country code: {data.CountryCode}");
        Console.WriteLine($"\t\t Postal code: {data.PostalCode}");
    }

    private static void PrintBulkData(IPGeolocateBulkData data)
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
            var req = new IPGeolocateBulkRequest.Builder(new string[] {"93.231.182.110", "190.28.74.251"})
                .WithProvider("digitalelement")
                .WithVerbose(true)
                .WithRaw(true)
                .Build();

            // Send request
            var res = await client.GeolocateBulk(req);

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
