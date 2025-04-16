# docs

This directory contains some custom tooling for generating machine-readable
API documentation for the [Pangea .NET docs][]. At a high level, the pipeline
works like so:

1. The MSBuild compiler generates XML documentation.
2. [docfx][] generates YAML documentation with more metadata than what MSBuild
   provides.
3. The tooling here combines these two sources of documentation, makes some
   types prettier, and trims out extraneous data.
4. The resulting JSON file is brought into the Pangea docs site.

## Prerequisites

- Node.js v20.10.0 or higher.
- yarn v4 or higher.
- .NET SDK 8.0 or higher.
- docfx (`dotnet tool install --global docfx`)

## Instructions

Starting from the root of the repository:

```bash
$ dotnet build --configuration Release packages/pangea-sdk/
$ cd docs/
$ yarn
$ docfx metadata docfx.json
$ yarn generate
```

[Pangea .NET docs]: https://pangea.cloud/docs/sdk/csharp/
[docfx]: https://dotnet.github.io/docfx/index.html
