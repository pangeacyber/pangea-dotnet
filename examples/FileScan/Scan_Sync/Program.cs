using PangeaCyber.Net;
using PangeaCyber.Net.FileScan;
using PangeaCyber.Net.Exceptions;
using System.Text;
using System.Security.Cryptography;


class Program
{

    static async Task Main(string[] args)
    {
        try
        {
            // Load client config. Can create it manually with Config constructor and setters
            var clientCfg = Config.FromEnvironment("file-scan");

            // To work in sync it's need to set up queuedRetryEnabled to true and set up a
            // proper timeout
            // If timeout it's so little service won't end up and will return an
            // AcceptedRequestException anyway
            clientCfg.QueuedRetryEnabled = true;
            clientCfg.PollResultTimeoutSecs = 120;

            // Create FileScanClient with builder
            FileScanClient client = new FileScanClient.Builder(clientCfg).Build();

            // Set your filepath to scan
            string filepath = "./testfile.pdf";

            // Open file in read mode
            var file = new FileStream(filepath, FileMode.Open, FileAccess.Read);

            // Create request
            var request = new FileScanRequest.Builder().WithProvider("crowdstrike").WithRaw(true).WithVerbose(true).Build();

            // Send request
            var response = await client.Scan(request, file);

            FileScanData data = response.Result.Data;

            // If success, print result
            Console.WriteLine($"Success. Verdict: {data.Verdict}");
            if( response.Result.RawData != null ) {
                Console.WriteLine("Raw provider data:");
                foreach (KeyValuePair<string, object> kvp in response.Result.RawData)
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
