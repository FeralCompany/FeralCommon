# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/ 'Keep a Changelog, 1.1.0'),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html 'Semantic Versioning, 2.0.0').

## [Unreleased]

## Version [v0.0.8] (2024-04-15)

- History will forgive me these sins.

## Version [v0.0.7] (2024-04-15)

### Changed

- Fixed various aspects of build cycle.
- No code updates.
- Just testing build cycle changes.

## Version [v0.0.6] (2024-04-15)

### Added

- Abstract Harmony initializer with lazy access to Harmony instance
- Various utilities
- Tightened scopes where possible
- Better README.md
    - Added usage examples and a link to the contribution guidelines

### Changed

- [InputUtils](https://thunderstore.io/c/lethal-company/p/Rune580/LethalCompany_InputUtils 'InputUtils by Rune580')
  and [LethalConfig](https://thunderstore.io/c/lethal-company/p/AinaVT/LethalConfig 'LethalConfig by AinaVT') are now hard dependencies.
    - I can no longer be arsed to deal with the nightmare that is soft dependencies. With how efficient Thunderstore and r2modman are, there's no
      downside to having them as hard dependencies.
    - With this change, I think that usage is even better than before, and significantly less confusing.

## Version [v0.0.5] (2024-04-14)

### Added

- Added BoolConfig
- Added support for `ButtonPress` and `ButtonToggle`
- Soft [InputUtils](https://thunderstore.io/c/lethal-company/p/Rune580/LethalCompany_InputUtils 'InputUtils by Rune580') integration

### Fixed

- Added missing converter for ColorConfig
- Fixed `Start` and `Update` methods not being called

## Version [v0.0.4] (2024-04-12)

### Added

- Added `FeralCommon.Config.ColorConfig`
- Added implicit operators for `ConfigEntry` and `ColorEntry.Value`

## Version [v0.0.3] (2024-04-12)

### Fixes

- Fixed build and packaging issues.

## Version [v0.0.2] (2024-04-11)

### Added

- Soft [LethalConfig](https://thunderstore.io/c/lethal-company/p/AinaVT/LethalConfig 'LethalConfig by AinaVT') integration

## Version [v0.0.1] (2024-04-08)

### Added

- Initial release
