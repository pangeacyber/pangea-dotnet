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

            // To work in async it's need to set up queuedRetryEnabled to false
            // When we call .scan() it will return an AcceptedRequestException inmediatly if
            // server return a 202 response
            clientCfg.QueuedRetryEnabled = false;

            // Create FileScanClient with builder
            FileScanClient client = new FileScanClient.Builder(clientCfg).Build();

            // Set your filepath to scan
            string filepath = "./testfile.pdf";

            // Open file in read mode
            var file = new FileStream(filepath, FileMode.Open, FileAccess.Read);

            // Create request
            var request = new FileScanRequest.Builder().WithProvider("crowdstrike").WithRaw(true).WithVerbose(true).Build();

            string requestID = "";

            try {
                // Send request
                Console.WriteLine("FileScan request...");
                var response = await client.Scan(request, file);
                FileScanData data = response.Result.Data;

                // If success, print result
                Console.WriteLine($"Success on first request. Verdict: {data.Verdict}");
                if( response.Result.RawData != null ) {
                    Console.WriteLine("Raw provider data:");
                    foreach (KeyValuePair<string, object> kvp in response.Result.RawData)
                    {
                        Console.WriteLine("\"{0}\": {1}", kvp.Key, kvp.Value);
                    }
                }
                return;
            } catch (AcceptedRequestException e){
                Console.WriteLine("AcceptedRequestException received (as expected)");
                requestID = e.RequestID;
            }

            Console.WriteLine("Let's wait until result is (should be) ready");
            // Sleep 20 seconds until result is (should be) ready
            await Task.Delay(20 * 1000);

            Console.WriteLine("PollResult request...");
            // Poll result, this could raise another AcceptedRequestException if result is not ready
            var responsePoll = await client.PollResult<FileScanResult>(requestID);

            // If success, print result
            FileScanData dataPoll = responsePoll.Result.Data;
            Console.WriteLine($"Success on PollResult. Verdict: {dataPoll.Verdict}");
            if( responsePoll.Result.RawData != null ) {
                Console.WriteLine("Raw provider data:");
                foreach (KeyValuePair<string, object> kvp in responsePoll.Result.RawData)
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
