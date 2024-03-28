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
        RequestTransferMethod = TransferMethod.PostURL,
        UploadedFileName = "sample.pdf",
    },
    file
);
Console.WriteLine($"Sanitized file is available at <{response.Result.DestURL}>.");
