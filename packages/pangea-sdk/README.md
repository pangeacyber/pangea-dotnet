<a href="https://pangea.cloud?utm_source=github&utm_medium=dotnet-sdk" target="_blank" rel="noopener noreferrer">
  <img src="https://pangea-marketing.s3.us-west-2.amazonaws.com/pangea-color.svg" alt="Pangea Logo" height="40" />
</a>

<br />

[![Documentation](https://img.shields.io/badge/documentation-pangea-blue?style=for-the-badge&labelColor=551B76)][Documentation]

# Pangea .NET SDK

A .NET SDK for integrating with Pangea services.
Supports .NET 8, .NET Standard 2.0, .NET Framework v4.6.2, and any other target
framework that's compatible with these.

## Installation

#### GA releases

Via .NET CLI:

```bash
$ dotnet add package Pangea.SDK
```

Via PackageReference:

```xml
<PackageReference Include="Pangea.SDK" Version="*" />
```

<a name="beta-releases"></a>

#### Beta releases

Pre-release versions may be available with the `beta` denotation in the version
number. These releases serve to preview Beta and Early Access services and APIs.
Per Semantic Versioning, they are considered unstable and do not carry the same
compatibility guarantees as stable releases. [Beta changelog][].

Via .NET CLI:

```bash
$ dotnet add package Pangea.SDK --version 5.2.0-beta.2
```

Via PackageReference:

```xml
<PackageReference Include="Pangea.SDK" Version="5.2.0-beta.2" />
```

## Usage

- [Documentation][]
- [GA Examples][]
- [Beta Examples][]

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

## Configuration

The SDK supports the following configuration options via `Config`:

- `Token` — Pangea API token.
- `BaseUrlTemplate` — Template for constructing the base URL for API requests.
  The placeholder `{SERVICE_NAME}` will be replaced with the service name slug.
  This is a more powerful version of `Domain` that allows for setting more than
  just the host of the API server. Defaults to
  `https://{SERVICE_NAME}.aws.us.pangea.cloud`.
- `Domain` — Base domain for API requests. This is a weaker version of
  `BaseUrlTemplate` that only allows for setting the host of the API server. Use
  `BaseUrlTemplate` for more control over the URL, such as setting
  service-specific paths.
- `ConnectionTimeout` — Time span to wait before a HTTP request times out.
- `CustomUserAgent` — User-Agent string to append to the default one.
- `QueuedRetryEnabled` — Whether or not queued request retries are enabled.
- `PollResultTimeoutSecs` — Timeout for polling results after a HTTP/202 (in
  seconds).

[Documentation]: https://pangea.cloud/docs/sdk/csharp/
[GA Examples]: https://github.com/pangeacyber/pangea-dotnet/tree/main/examples
[Beta Examples]: https://github.com/pangeacyber/pangea-dotnet/tree/beta/examples
[Pangea Console]: https://console.pangea.cloud/
[Secure Audit Log]: https://pangea.cloud/docs/audit
[Beta changelog]: https://github.com/pangeacyber/pangea-dotnet/blob/beta/packages/pangea-sdk/CHANGELOG.md
