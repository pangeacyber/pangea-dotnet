
[![documentation](https://img.shields.io/badge/documentation-pangea-blue?style=for-the-badge&labelColor=551B76)](https://pangea.cloud/docs/sdk/csharp/)
[![Slack](https://img.shields.io/badge/Slack-4A154B?style=for-the-badge&logo=slack&logoColor=white)](https://pangea.cloud/join-slack/)


# Pangea .NET SDK

This package helps .NET developers to use Pangea's security services in their applications. In order to use the services, developers need to [register](https://login.aws.us.pangea.cloud/signup) for a Pangea account and obtain an API token.


## Links

- [Pangea Registration](https://login.aws.us.pangea.cloud/signup)
- [Pangea .NET SDK Repository](https://github.com/pangeacyber/pangea-dotnet)
- [Documentation](https://pangea.cloud/docs/sdk/csharp/)


## Build

In order to build SDK run:

```
dotnet build
```


## SDK Logger setup

For logging purpose this SDK use NLog package. In order to setup it copy [NLog.config](./NLog.config) file from this directory to your root app directory
In order to get more information about this configuration file, please visit https://github.com/NLog/NLog/wiki/Configuration-file
