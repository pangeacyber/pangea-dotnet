# Contributing

Currently, the setup scripts only have support for Mac/ZSH environments.
Future support is incoming.

To install our linters, simply run `./dev/setup_repo.sh`
These linters will run on every `git commit` operation.

## Publishing

Publishing Pangea.SDK to the NuGet registry is handled via a private GitLab CI
pipeline. This pipeline is triggered when a Git tag is pushed to the repository.
Git tags should be formatted as `vX.Y.Z`, where `vX.Y.Z` is the version number
to publish.

1. Update `<Version>` in `packages/pangea-sdk/PangeaCyber.Net/PangeaCyber.Net.csproj`.
2. Update the version in `packages/pangea-sdk/VERSION`.
3. Update the `Version` value in `packages/pangea-sdk/PangeaCyber.Net/Config.cs`.
4. Update the release notes in `packages/pangea-sdk/CHANGELOG.md`.
5. Author a commit with this change and land it on `main`.
6. `git tag -m v1.0.0 v1.0.0 0000000`. Replace `v1.0.0` with the new version
  number and `0000000` with the commit SHA from the previous step.
7. `git push --tags origin main`.

From here the GitLab CI pipeline will pick up the pushed Git tag and publish
the package to the NuGet registry.
