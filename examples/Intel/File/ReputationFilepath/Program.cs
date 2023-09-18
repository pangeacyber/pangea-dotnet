using PangeaCyber.Net;
using PangeaCyber.Net.Intel;
using PangeaCyber.Net.Exceptions;
using System.Text;
using System.Security.Cryptography;


class Program
{
    public static string Bytes2Hex(byte[] bytes) {
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2")); // Convert each byte to its hexadecimal representation
            }
            return builder.ToString();
    }

    public static string GetSHA256HashFromFilepath(string filepath) {
        using (FileStream stream = File.OpenRead(filepath))
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(stream);
                return Bytes2Hex(hashBytes);
            }
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

            // Create hash from filepath
            string hash = GetSHA256HashFromFilepath("./testfile.pdf");

            // Create request
            var req = new FileHashReputationRequest.Builder(hash, "sha256")
                .WithProvider("reversinglabs")
                .WithVerbose(true)
                .WithRaw(true)
                .Build();

            // Send request
            var res = await client.Reputation(req);

            // If success, print result
            Console.WriteLine($"Success. Verdict: {res.Result.Data.Verdict}");
            if( res.Result.RawData != null ) {
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
