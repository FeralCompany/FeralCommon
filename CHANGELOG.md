# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/ 'Keep a Changelog, 1.1.0'),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html 'Semantic Versioning, 2.0.0').

## [Unreleased]

- Nothing, yet.

## Version [v0.2.0] (2024-04-27)

### Added

- Add `GameItem` enum and `GameItems` utility class.
    - Additionally, added `GameItemExtensions` for convenience methods against the enum.
- Added `GameObjectExtensions`.
- Added `GrabbableObjectExtensions`.
- Added `NumberExtensions`.

### Changed

- `ObjectInspector` now expands all types by default, so detailedTypes is no longer necessary.

### Fixed

- `ObjectInspector` would get stuck on a few types. This has been fixed.

## Version [v0.1.3] (2024-04-23)

### Added

- Added `HarmonyExtension`, namely `PatchNamespace` which scans the provided namespace and requests each type within to be patched.

## Version [v0.1.2] (2024-04-23)

### Changed

- Better looking mod icon.

## Version [v0.1.1] (2024-04-23)

### Added

- Added `Diff` to `ObjectInspector`.
- Added `Mask`
- Added `EnumConfig`
- Added normalized log output for `ObjectInspector`
- Removed `UnityTool`

### Fixed

- Don't use ranges in Configs if no Min/Max is specified.

## Version [v0.1.0] (2024-04-19)

### Added

- Add ObjectInspector
- Add UnityTool
- Add `LocalPlayerNullable` to `Player` utility

### Changed

- Update LethalConfig dependency to 1.4.1
    - Make use of its optional assembly specification (thanks AinaVT! <3)
- `activeByDefault` optional parameter in `ButtonToggle`

### Trivial

- Change website url on Thunderstore to https://github.com/FeralCompany

## Version [v0.0.7 -> v0.0.12] (2024-04-15)

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
