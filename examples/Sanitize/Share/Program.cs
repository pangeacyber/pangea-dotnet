using PangeaCyber.Net;
using PangeaCyber.Net.Sanitize;

var cfg = Config.FromEnvironment("sanitize");
var client = new SanitizeClient.Builder(cfg).Build();

// Pick a file to sanitize.
var file = new FileStream("./sample.pdf", FileMode.Open, FileAccess.Read);

// Sanitize the file.
var response = await client.Sanitize(
    new SanitizeRequest()
    {
        ShareOutput = new ShareOutput
        {
            Enabled = true,
            OutputFolder = "/sdk_examples/sanitize/"
        },
        UploadedFileName = "sample.pdf",
    },
    file
);
Console.WriteLine($"Sanitized file is available in Secure Share with ID '{response.Result.DestShareID}'.");
