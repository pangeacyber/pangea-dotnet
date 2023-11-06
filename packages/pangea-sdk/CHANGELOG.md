# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [3.0.0] - 2023-10-23

# Added 

- AuthN v2 support 

# Removed

- AuthN v1 support


## [2.4.0] - 2023-09-26

# Added

- FileScan Reversinglabs provider example
- Domain WhoIs endpoint support
- AuthN Filters support

# Changed

- Deprecated config_id in PangeaConfig. Now is set in service initialization.


## [2.3.0] - 2023-09-05

# Added

- Redact rulesets field support 
- FileScan service support


## [2.2.0] - 2023-07-28 

# Added

- AuthN, Embargo, Intel and Vault service examples
- Base64ToString, GetSHA256Hash and GetHashPrefix in Utils

# Changed

- Make ServiceName public in AuthN, Embargo, Intel and Vault services

# Fixed

- Audit public key format export in log signer


## [2.1.0] - 2023-07-26 

# Added 

- Embargo service support
- Intel services (IP, Domain, File, URL) support
- Vault service support
- AuthN service support
- Audit service examples
- Redact service examples


## [2.0.0] - 2023-07-14

# Added

- Audit custom schema support 
- Multiconfig support 
- Custom user agent support

# Changed

- Redact requests builder rename to be called just "Builder" 


[unreleased]: https://github.com/pangeacyber/pangea-dotnet/compare/v2.4.0...main
[2.4.0]: https://github.com/pangeacyber/pangea-dotnet/compare/v2.3.0...v2.4.0
[2.3.0]: https://github.com/pangeacyber/pangea-dotnet/compare/v2.2.0...v2.3.0
[2.2.0]: https://github.com/pangeacyber/pangea-dotnet/compare/v2.1.0...v2.2.0
[2.1.0]: https://github.com/pangeacyber/pangea-dotnet/compare/v2.0.0...v2.1.0
[2.0.0]: https://github.com/pangeacyber/pangea-dotnet/releases/tag/v2.0.0
