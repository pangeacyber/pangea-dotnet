# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## 3.8.0-beta.1 - 2024-03-18

### Added

- Documentation for client builders and constructors.
- Audit /download_results endpoint support
- Sanitize service support

### Fixed

- Put to presigned url. It should just put file in raw, not in form format.

### Changed

- Skip sending `filename` field when posting to presigned URL. Make GCP S3 to return a `BadRequest`


## [3.7.0] - 2024-02-26

### Added 

- Vault service. Post quantum signing algorithms support

### Changed

- Rewrote `README.md`.


## [3.6.0] - 2024-01-11

### Added

- Structured encrypt support.

## [3.5.1] - 2023-12-22

### Changed

- Update `FileScanUploadURLRequest` namespace to `PangeaCyber.Net.FileScan`


## [3.5.0] - 2023-12-18

### Added

- File Intel /v2/reputation support
- IP Intel /v2/reputation, /v2/domain, /v2/proxy, v2/vpn and /v2/geolocate support
- URL Intel /v2/reputation support
- Domain Intel /v2/reputation support
- User Intel /v2/user/breached and /v2/password/breached support


## [3.4.0] - 2023-12-07

### Changed

- 202 result format

### Removed

- accepted_status in 202 result

### Added

- put_url, post_url, post_form_data fields in 202 result


## [3.3.0] - 2023-11-28

### Added

- Audit bulk examples
- Authn unlock user support
- Redact multiconfig support
- Filescan post-url and put-url support

### Fixed

- Audit bulk async does not poll result by default


## [3.2.0] - 2023-11-15

### Added

- Support for audit /v2/log and /v2/log_async endpoints


## [3.1.0] - 2023-11-09

### Added

- Presigned URL upload support on FileScan service
- Folder settings support in Vault service

## [3.0.0] - 2023-10-23

### Added

- AuthN v2 support

### Removed

- AuthN v1 support


## [2.4.0] - 2023-09-26

### Added

- FileScan Reversinglabs provider example
- Domain WhoIs endpoint support
- AuthN Filters support

### Changed

- Deprecated config_id in PangeaConfig. Now is set in service initialization.


## [2.3.0] - 2023-09-05

### Added

- Redact rulesets field support
- FileScan service support


## [2.2.0] - 2023-07-28

### Added

- AuthN, Embargo, Intel and Vault service examples
- Base64ToString, GetSHA256Hash and GetHashPrefix in Utils

### Changed

- Make ServiceName public in AuthN, Embargo, Intel and Vault services

### Fixed

- Audit public key format export in log signer


## [2.1.0] - 2023-07-26

### Added

- Embargo service support
- Intel services (IP, Domain, File, URL) support
- Vault service support
- AuthN service support
- Audit service examples
- Redact service examples


## [2.0.0] - 2023-07-14

### Added

- Audit custom schema support
- Multiconfig support
- Custom user agent support

### Changed

- Redact requests builder rename to be called just "Builder"


[unreleased]: https://github.com/pangeacyber/pangea-dotnet/compare/v3.7.0...main
[3.7.0]: https://github.com/pangeacyber/pangea-dotnet/compare/v3.6.0...v3.7.0
[3.6.0]: https://github.com/pangeacyber/pangea-dotnet/compare/v3.5.1...v3.6.0
[3.5.1]: https://github.com/pangeacyber/pangea-dotnet/compare/v3.5.0...v3.5.1
[3.5.0]: https://github.com/pangeacyber/pangea-dotnet/compare/v3.4.0...v3.5.0
[3.4.0]: https://github.com/pangeacyber/pangea-dotnet/compare/v3.3.0...v3.4.0
[3.3.0]: https://github.com/pangeacyber/pangea-dotnet/compare/v3.2.0...v3.3.0
[3.2.0]: https://github.com/pangeacyber/pangea-dotnet/compare/v3.1.0...v3.2.0
[3.1.0]: https://github.com/pangeacyber/pangea-dotnet/compare/v3.0.0...v3.1.0
[3.0.0]: https://github.com/pangeacyber/pangea-dotnet/compare/v2.4.0...v3.0.0
[2.4.0]: https://github.com/pangeacyber/pangea-dotnet/compare/v2.3.0...v2.4.0
[2.3.0]: https://github.com/pangeacyber/pangea-dotnet/compare/v2.2.0...v2.3.0
[2.2.0]: https://github.com/pangeacyber/pangea-dotnet/compare/v2.1.0...v2.2.0
[2.1.0]: https://github.com/pangeacyber/pangea-dotnet/compare/v2.0.0...v2.1.0
[2.0.0]: https://github.com/pangeacyber/pangea-dotnet/releases/tag/v2.0.0
