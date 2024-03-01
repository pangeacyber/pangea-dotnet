<a href="https://pangea.cloud?utm_source=github&utm_medium=dotnet-sdk" target="_blank" rel="noopener noreferrer">
  <img src="https://pangea-marketing.s3.us-west-2.amazonaws.com/pangea-color.svg" alt="Pangea Logo" height="40" />
</a>

<br />

[![documentation](https://img.shields.io/badge/documentation-pangea-blue?style=for-the-badge&labelColor=551B76)][Documentation]
[![Slack](https://img.shields.io/badge/Slack-4A154B?style=for-the-badge&logo=slack&logoColor=white)][Slack]

# Pangea .NET SDK

A .NET SDK for integrating with Pangea services.
Supports .NET 6, .NET Standard 2.0, .NET Framework v4.6.1, and any other target
framework that's compatible with these.

## Installation

Via .NET CLI:

```bash
$ dotnet add package Pangea.SDK
```

Via PackageReference:

```xml
<PackageReference Include="Pangea.SDK" Version="*" />
```

## Usage

- [Documentation][]
- [Examples][]

General usage would be to create a token for a service through the
[Pangea Console][] and then construct an API client for that respective service.
The below example shows how this can be done for [Secure Audit Log][] to log a
simple event:

```csharp
using PangeaCyber.Net;
using PangeaCyber.Net.Audit;

// Load client configuration from environment variables `PANGEA_AUDIT_TOKEN` and
// `PANGEA_DOMAIN`.
var config = Config.FromEnvironment(AuditClient.ServiceName);

// Create a Secure Audit Log client.
var client = new AuditClient.Builder(config).Build();

// Create a basic event.
var event = new StandardEvent.Builder("Hello World!")
    .WithAction("Login")
    .WithActor("Terminal")
    .Build();

// Optional configuration.
var logConfig = new LogConfig.Builder()
    .WithVerbose(true)
    .Build();

// Log the event.
var response = await client.Log(event, logConfig);
```



   [Documentation]: https://pangea.cloud/docs/sdk/csharp/
   [Examples]: https://github.com/pangeacyber/pangea-dotnet/tree/main/examples
   [Pangea Console]: https://console.pangea.cloud/
   [Slack]: https://pangea.cloud/join-slack/
   [Secure Audit Log]: https://pangea.cloud/docs/audit
