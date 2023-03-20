<p>
  <br />
  <a href="https://pangea.cloud?utm_source=github&utm_medium=node-sdk" target="_blank" rel="noopener noreferrer">
    <img src="https://pangea-marketing.s3.us-west-2.amazonaws.com/pangea-color.svg" alt="Pangea Logo" height="40">
  </a>
  <br />
</p>

<p>
<br />

[![documentation](https://img.shields.io/badge/documentation-pangea-blue?style=for-the-badge&labelColor=551B76)](https://pangea.cloud/docs/sdk/python/)
[![Slack](https://img.shields.io/badge/Slack-4A154B?style=for-the-badge&logo=slack&logoColor=white)](https://pangea.cloud/join-slack/)

<br />
</p>

# Pangea .Net SDK Repo

A .Net SDK for integrating with Pangea Services.

## Repo Contents

In this repo we have the following structure

```
    /PangeaCyber.Net        --- The actual SDK source code
    /PangeaCyber.Tests      --- Integration xunit test suite for testing the SDK functionality
    /PangeaCyber.SampleApp  --- A sample C# console app to demonstrate the usage of the SDK   
```

## Limitations

Although Pangea offers many valuable services, this SDK only supports the Secure Audit Service as of now. Other services will become available shortly.


## Setup

In order to run and debug the library, you will need .net runtime set up on your computer. You can download the correct installer from https://dotnet.microsoft.com/en-us/download

After downloading and installing the framework, open a terminal session and make sure that things are in order by running the command below:

```
dotnet --list-runtimes
```

The command should list the available runtimes on your computer. You can add and remove runtime and sdks using the `dotnet` utility. 

To learn more about the `dotnet` tool, please visit https://learn.microsoft.com/en-us/dotnet/core/tools/



## Usage

The SDK requires a pangea service domain and a service token. Both values can be passed as an environment variables or as a constructor parameter. 

### Example: Secure Audit Service - Log Data

```
using PangeaCyber.Net;
using PangeaCyber.Net.Audit;

class Program
{
    static async Task Main(string[] args)
    {
        // This will look for PANGEA_AUDIT_TOKEN and PANGEA_DOMAIN environment variables
        var config = Config.FromEnvironment("audit"); 
        AuditClientBuilder builder = new AuditClientBuilder(config);
        var client = builder.Build();

        try
        {
            // Let's log our first message
            var evt = new Event("Hello World! " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            var res1 = await client.Log(evt);

            Console.WriteLine("Hash: " + res1.Result.Hash);

            // We can add more details to the audit log, like actor, action, source, etc
            evt.Actor = "PangeaCyber.SampleApp";
            evt.Action = "Auditable Action";
            evt.Source = "Sample source";
            evt.Old = "Tracking value changes, this is the old value";
            evt.NewField = "the new value";

            var res2 = await client.Log(evt);
            Console.WriteLine("Hash: " + res2.Result.Hash);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed with exception: " + ex.Message);
        }
    }
}

```

### Secure Audit Service - Search Data

```
using PangeaCyber.Net;
using PangeaCyber.Net.Audit;

class Program
{
    static async Task Main(string[] args)
    {
        // This will look for PANGEA_AUDIT_TOKEN and PANGEA_DOMAIN environment variables
        var config = Config.FromEnvironment("audit"); 
        AuditClientBuilder builder = new AuditClientBuilder(config);
        var client = builder.Build();

        try
        {
            var input = new SearchInput("message:");
            input.Limit = 5;

            var res = await client.Search(input);
            Console.WriteLine("Search Result Count: " + res.Result.Events.Count());
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed with exception: " + ex.Message);
        }
    }
}
```

