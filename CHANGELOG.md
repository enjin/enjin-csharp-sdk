# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [1.0.0-alpha.2] - 2021-11-09
### Added
- Added [Enjin Bridge mutations](https://docs.enjin.io/enjin-api/sending-and-receiving-requests/enjin-bridge)
for project and player schemas.
- Added `Asset` property to `Request`.
- Added `AssetIdFormat` method to `ITransactionFragmentArguments`.

### Changed
- Changed versioning for project to follow [Semantic Versioning](https://semver.org/spec/v2.0.0.html).
- Changed project information in preparation for NuGet package release.
- The asset for transactions is now included in returned `Request` models when using `WithAssetData()` in
requests which implement `ITransactionFragmentArguments`.

### Fixed
- Schema requests to the platform no longer serialize arguments that have not been set.
- Fixed type constraints on methods in `ITransactionFragmentArguments`.

## [1.0.0.1000] - 2021-09-27
### Added
- Initial alpha release.

[Unreleased]: https://github.com/enjin/enjin-csharp-sdk/compare/1.0.0.alpha.2...HEAD
[1.0.0-alpha.2]: https://github.com/enjin/enjin-csharp-sdk/compare/1.0.0.1000...1.0.0.alpha.2
[1.0.0.1000]: https://github.com/enjin/enjin-csharp-sdk/releases/tag/1.0.0.1000