using System.CommandLine;
using PangeaCyber.Net;
using PangeaCyber.Net.Share;
using PangeaCyber.Net.Share.Models;
using PangeaCyber.Net.Share.Requests;

var inputOption = new Option<FileInfo>("--input", "Local path to upload.") { IsRequired = true };
var destOption = new Option<string>("--dest", () => "/", "Destination path in Share.");
var emailOption = new Option<string>("--email", "Email address to protect the share link with.");
var phoneOption = new Option<string>("--phone", "Phone number to protect the share link with.");
var passwordOption = new Option<string>("--password", "Password to protect the share link with.");
var linkTypeOption = new Option<LinkType>("--link-type", () => LinkType.Download, "Type of link.");

var rootCommand = new RootCommand();
rootCommand.AddOption(inputOption);
rootCommand.AddOption(destOption);
rootCommand.AddOption(emailOption);
rootCommand.AddOption(phoneOption);
rootCommand.AddOption(passwordOption);
rootCommand.AddOption(linkTypeOption);

rootCommand.SetHandler(async (input, dest, email, phone, password, linkType) =>
{
    if (string.IsNullOrWhiteSpace(email) && string.IsNullOrWhiteSpace(phone) && string.IsNullOrWhiteSpace(password))
    {
        Console.Error.WriteLine("At least one of --email, --phone, or --password must be provided.");
        return;
    }

    var authenticators = new List<Authenticator>();
    if (!string.IsNullOrWhiteSpace(password))
    {
        authenticators.Add(new Authenticator(AuthenticatorType.Password, password));
    }
    if (!string.IsNullOrWhiteSpace(email))
    {
        authenticators.Add(new Authenticator(AuthenticatorType.EmailOtp, email));
    }
    if (!string.IsNullOrWhiteSpace(phone))
    {
        authenticators.Add(new Authenticator(AuthenticatorType.SmsOtp, phone));
    }


    var token = Config.LoadEnvironmentVariable("PANGEA_SHARE_TOKEN");
    var domain = Config.LoadEnvironmentVariable("PANGEA_DOMAIN");
    var config = new Config(token, domain);
    var share = new ShareClient.Builder(config).Build();

    var files = input.Attributes.HasFlag(FileAttributes.Directory)
        ? new DirectoryInfo(input.FullName).GetFiles()
        : new[] { input };
    var objectIds = new List<string>();
    foreach (var file in files)
    {
        await using var fileStream = file.OpenRead();
        var uploadResponse = await share.Put(new PutRequest
        {
            Folder = $"{dest}/{file.Name}",
            RequestTransferMethod = TransferMethod.PostURL
        }, fileStream);
        objectIds.Add(uploadResponse.Result.Object.ID);
    }

    var linkResponse = await share.ShareLinkCreate(new ShareLinkCreateRequest
    {
        Links = new List<ShareLinkCreateItem>
        {
            new() {
                Targets = objectIds,
                LinkType = linkType,
                Authenticators = authenticators
            }
        }
    });

    Console.WriteLine(linkResponse.Result.ShareLinkObjects[0].Link);
}, inputOption, destOption, emailOption, phoneOption, passwordOption, linkTypeOption);

await rootCommand.InvokeAsync(args);
