using PangeaCyber.Net;
using PangeaCyber.Net.Share;
using PangeaCyber.Net.Share.Models;
using PangeaCyber.Net.Share.Requests;

var token = Config.LoadEnvironmentVariable("PANGEA_SHARE_TOKEN");
var domain = Config.LoadEnvironmentVariable("PANGEA_DOMAIN");

var config = new Config(token, domain);
var client = new ShareClient.Builder(config).Build();

// Mock data.
var time = DateTimeOffset.UtcNow.ToString("yyyyMMdd_HHmmss");
var folder = $"/sdk_examples/{time}";

// Create a folder.
var folderCreateResponse = await client.FolderCreate(new FolderCreateRequest
{
    Path = folder
});
var folderId = folderCreateResponse.Result.Object.ID;
Console.WriteLine($"Created folder with ID '{folderId}'.");

// Upload a file with metadata and tags to the folder.
var metadata = new Metadata
{
    { "key", "value" }
};

var tags = new Tags
{
    "tag1"
};

var file = new FileStream("./sample.txt", FileMode.Open);
var putResponse = await client.Put(
    new PutRequest
    {
        Metadata = metadata,
        ParentId = folderId,
        RequestTransferMethod = TransferMethod.PostURL,
        Tags = tags,
    },
    file
);
var fileId = putResponse.Result.Object.ID;
Console.WriteLine($"Uploaded file with ID '{fileId}'.");

// Get an archive containing the folder's contents.
var archiveResponse = await client.GetArchive(new GetArchiveRequest
{
    Format = ArchiveFormat.Zip,
    IDs = new List<string> { folderId },
    RequestTransferMethod = TransferMethod.DestURL
});
Console.WriteLine($"Archive with {archiveResponse.Result.Count} items is available at <{archiveResponse.Result.DestUrl}>.");

// Later on, if desired, the folder can be deleted.
await client.Delete(new DeleteRequest { ID = folderId, Force = true });
