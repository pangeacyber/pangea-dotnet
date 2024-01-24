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
            // Load client config. Can create it manually with Config constructor and setters.
            var clientCfg = Config.FromEnvironment("file-scan");

            // To work in async it's necessary to set `QueuedRetryEnabled` to false.
            // When we call .scan() it will throw an AcceptedRequestException immediately if
            // server returns a 202 response.
            clientCfg.QueuedRetryEnabled = false;

            // Create FileScanClient with builder
            FileScanClient client = new FileScanClient.Builder(clientCfg).Build();

            // Set your filepath to scan
            string filepath = "./testfile.pdf";

            // Create request
            var request = new FileScanUploadURLRequest.Builder().WithProvider("reversinglabs").WithVerbose(true).WithRaw(true).WithTransferMethod(TransferMethod.PutURL).Build();

            // Request upload url
            var urlResponse = await client.RequestUploadURL(request);

            // Open file in read mode
            var file = new FileStream(filepath, FileMode.Open, FileAccess.Read);

            // Create FileData with PostFormData from response
            var fileData = new FileData(file, "file");
            string url = urlResponse.Result.PutURL ?? "undefined url";    // This case should never happen

            // Create uploader and upload file
            var uploader = new FileUploader.Builder().Build();
            await uploader.UploadFile(url, TransferMethod.PutURL, fileData);

            // Let's poll the result
            Console.WriteLine("Poll result...");
            int maxRetry = 24;
            for (int retry = 0; retry < maxRetry; retry++)
            {
                try
                {
                    // Sleep 10 seconds until result is (should) be ready
                    await Task.Delay(10 * 1000);

                    // Poll result, this could raise another AcceptedRequestException if result is not ready
                    var response = await client.PollResult<FileScanResult>(urlResponse.RequestId);
                    Console.WriteLine($"Success on PollResult. Verdict: {response.Result.Data.Verdict}");
                    if (response.Result.RawData != null)
                    {
                        Console.WriteLine("Raw provider data:");
                        foreach (KeyValuePair<string, object> kvp in response.Result.RawData)
                        {
                            Console.WriteLine("\"{0}\": {1}", kvp.Key, kvp.Value);
                        }
                    }
                    break;
                }
                catch (AcceptedRequestException)
                {
                    Console.WriteLine(string.Format("Result still not ready. Retry {0}", retry));
                }
            }
        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine("Failed with exception: " + e);
        }

    }
}
