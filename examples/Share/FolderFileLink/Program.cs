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
    Folder = folder
});
var folderId = folderCreateResponse.Result.Object.ID;
Console.WriteLine($"Created folder with ID '{folderId}'.");

// Upload a file to the folder.
var file = new FileStream("./sample.txt", FileMode.Open);
var putResponse = await client.Put(
    new PutRequest
    {
        ParentId = folderId,
        RequestTransferMethod = TransferMethod.PostURL
    },
    file
);
var fileId = putResponse.Result.Object.ID;
Console.WriteLine($"Uploaded file with ID '{fileId}'.");

// Create a share link for the file.
var authenticators = new List<Authenticator>
{
    new(AuthenticatorType.Password, "somepassword")
};
var linkList = new List<ShareLinkCreateItem>
{
    new() {
        Targets = new List<string> { fileId },
        LinkType = LinkType.Download,
        Authenticators = authenticators
    }
};

var shareResponse = await client.ShareLinkCreate(
    new ShareLinkCreateRequest
    {
        Links = linkList
    }
);
var shareLink = shareResponse.Result.ShareLinkObjects[0].Link;
Console.WriteLine($"Created share link: <{shareLink}>.");

// Later on, if desired, the folder can be deleted.
await client.Delete(new DeleteRequest { ID = folderId, Force = true });
