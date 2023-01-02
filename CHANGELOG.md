# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [1.0.0-beta.2] - 2023-01-02

### Added

- Added `UpdateName` request to `IProjectSchema`.

### Fixed

- Fixed GraphQL template argument type for `BridgeClaimAsset`.

### Security

- Updated dependency Newtonsoft.Json to `13.0.2` to address security vulnerability in library.

## [1.0.0-beta.1] - 2022-07-18

### Added

- Added `HttpLogLevel` enum values.
- Added reauthentication features to `ProjectClient`.

### Changed

- Renamed `AssetSort` to `AssetSortInput`.
- Renamed `Melt` to `MeltInput`.
- Renamed `PaginationOptions` to `PaginationInput`.
- Renamed `Request` to `Transaction`.
- Renamed `RequestState` to `TransactionState`.
- Renamed `RequestType` to `TransactionType`.
- Renamed `Trade` to `TradeInput`.
- Renamed `TransactionSort` to `TransactionSortInput`.
- Renamed `Transfers` to `TransferInput`.
- Renamed `GetRequest` to `GetTransaction`.
- Renamed `GetRequests` to `GetTransactions`.
- Renamed `IProjectTransactionRequestArguments` to `ITransactionRequestArguments`.
- Renamed `TrustedPlatformMiddleware` to `ClientMiddleware`.
- Renamed `TrustedPlatformHandler` to `ClientHandler`.
- `ClientHandler` now locks its authentication token with a mutex.
- Platform clients and event services now utilize builders.
- Replaced Boolean input to set HTTP debugging in platform clients and middleware with `HttpLogLevel` enum value.
- Replaced `JObject` type with `IDictionary<string, object>`.
- Replaced `IsConnected()` method in `IEventService` with property of the same name.
- Logger provider input for platform clients is now nullable.
- Logger provider input for `PusherEventService` is now nullable.
- The logger provider passed to the platform clients now handles HTTP logs when HTTP debugging is enabled.
- Reformatted HTTP log messages.
- Changed access of `HttpLoggingHandler` from public to internal.
- Changed access of `CreateRequestBody(OGraphqlRequest)` method in `BaseSchema` from protected to private.
- Changed access of JSON constructor in `GraphqlData` from public to internal.
- Added finalizers to platform clients.

### Removed

- Removed Refit as a dependency.
- Removed constructors from platform clients and event services.

## [1.0.0-alpha.7] - 2022-07-05

### Added

- Added `GOERLI` to `EnjinHosts`.

### Removed

- Removed `KOVAN` from `EnjinHosts`.

## [1.0.0-alpha.6] - 2022-05-23

### Added

- Added arguments and fields to `Transaction.gql` template file for getting the wallet address.
- Added arguments and fields to `Wallet.gql` template file for getting balances and transactions.
- Added `WithTransactionWalletAddress` extension method for `ITransactionFragmentArguments`.
- Added `WalletBalanceFilter`, `WithWalletBalances`, and `WithWalletTransactions` extension methods
  for `IWalletFragmentArguments`.
- Added `Wallet` property to `Request` model.
- Added `Balances` and `Transactions` properties to `Wallet` model.

### Changed

- Changed argument name in `Transaction.gql` template file from `assetIdFormat` to `withTransactionWalletAddress` to
  avoid name-collisions.
- Changed name of extension method for `ITransactionFragmentArguments` from `AssetIdFormat`
  to `TransactionAssetIdFormat`.
- `IWalletFragmentArguments` now implements `IBalanceFragmentArguments` and `ITransactionFragmentArguments`.

## [1.0.0-alpha.5] - 2022-04-25

### Changed

- Removed `ProjectUuid` and `ProjectUuidIn` methods from `BalanceFilter`.

## [1.0.0-alpha.4] - 2022-04-11

### Changed

- `GetWallets` query in project schema no longer implements `IPaginationArguments`.

### Fixed

- Fixed typo for `result` in `GetWallets.gql` template file for project schema.

## [1.0.0-alpha.3] - 2022-03-28

### Fixed

- Boolean responses of the `Delete` method in `IDelete` Refit service are now nullable.

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

[Unreleased]: https://github.com/enjin/enjin-csharp-sdk/compare/1.0.0-beta.2...HEAD

[1.0.0-beta.2]: https://github.com/enjin/enjin-csharp-sdk/compare/1.0.0-beta.1...1.0.0-beta.2

[1.0.0-beta.1]: https://github.com/enjin/enjin-csharp-sdk/compare/1.0.0-alpha.7...1.0.0-beta.1

[1.0.0-alpha.7]: https://github.com/enjin/enjin-csharp-sdk/compare/1.0.0-alpha.6...1.0.0-alpha.7

[1.0.0-alpha.6]: https://github.com/enjin/enjin-csharp-sdk/compare/1.0.0-alpha.5...1.0.0-alpha.6

[1.0.0-alpha.5]: https://github.com/enjin/enjin-csharp-sdk/compare/1.0.0-alpha.4...1.0.0-alpha.5

[1.0.0-alpha.4]: https://github.com/enjin/enjin-csharp-sdk/compare/1.0.0-alpha.3...1.0.0-alpha.4

[1.0.0-alpha.3]: https://github.com/enjin/enjin-csharp-sdk/compare/1.0.0-alpha.2...1.0.0-alpha.3

[1.0.0-alpha.2]: https://github.com/enjin/enjin-csharp-sdk/compare/1.0.0.1000...1.0.0-alpha.2

[1.0.0.1000]: https://github.com/enjin/enjin-csharp-sdk/releases/tag/1.0.0.1000