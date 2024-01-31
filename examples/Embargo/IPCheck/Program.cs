using PangeaCyber.Net;
using PangeaCyber.Net.Embargo;
using PangeaCyber.Net.Exceptions;


class Program
{

    static async Task Main(string[] args)
    {
        try
        {
            // Load client config. Can create it manually with Config constructor and setters
            var clientCfg = Config.FromEnvironment("embargo");

            // Create EmbargoClient with builder
            EmbargoClient client = new EmbargoClient.Builder(clientCfg).Build();

            // Request IP Check
            var res = await client.IPCheck("213.24.238.26");

            // If success, print sanctions
            Console.WriteLine($"Success. IP has {res.Result.Count} sanction/s.");
            if (res.Result.Sanctions != null)
            {
                foreach (var sanc in res.Result.Sanctions)
                {
                    Console.WriteLine($"Sanction: {sanc.IssuingCountry} embargoed {sanc.EmbargoedCountryName} ({sanc.EmbargoedCountryISOCode}) ");
                }
            }
        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine("Failed with exception: " + e.ToString());
        }
    }
}
