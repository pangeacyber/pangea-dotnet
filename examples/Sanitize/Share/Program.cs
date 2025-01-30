using PangeaCyber.Net;
using PangeaCyber.Net.Exceptions;
using PangeaCyber.Net.Sanitize;

var cfg = Config.FromEnvironment("sanitize");
var client = new SanitizeClient.Builder(cfg).Build();

// Pick a file to sanitize.
var file = new FileStream("./sample.txt", FileMode.Open, FileAccess.Read);

try
{
    // Sanitize the file.
    var response = await client.Sanitize(
        new SanitizeRequest()
        {
            RequestTransferMethod = TransferMethod.PostURL,
            ShareOutput = new ShareOutput
            {
                Enabled = true,
                OutputFolder = "/sdk_examples/sanitize/"
            },
            UploadedFileName = "sample.txt",
        },
        file
    );
    Console.WriteLine($"Sanitized file is available in Secure Share with ID '{response.Result.DestShareID}'.");
}
catch (AcceptedRequestException)
{
    Console.WriteLine("Result will be ready at a later time.");
}
