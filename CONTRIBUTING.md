# Contributing Guidelines

## Before You Commit Changes

1. Install [pre-commit](https://pre-commit.com/#install).
2. Install the pre-commit hooks by running the following command in the root of the repository:
    - `pre-commit install`
3. Any time you commit changes, the pre-commit hooks will run. If any of them fail, the commit will be aborted.
    - You can run the hooks manually by running the following command in the root of the repository:
    - `pre-commit run --all-files`

## Building the Project

First, create a new file in the `FeralCommon` directory named `FeralCommon.csproj.user`. This is a file that is ignored by git and is automatically included in the project file. This file is used to store user-specific settings, such as the path to the game's installation directory.

### Example `FeralCommon.csproj.user`

```xml
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="Current" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
    <PropertyGroup>
        <GameBaseDir>C:/Program Files (x86)/Steam/steamapps/common/Lethal Company</GameBaseDir>
        <ModProfileDir>$(APPDATA)/r2modmanPlus-local/LethalCompany/profiles/FeralCompany</ModProfileDir>
    </PropertyGroup>
    <Target Name="CopyToTestProfile" AfterTargets="PostBuildEvent" Condition="true">
        <MakeDir
                Directories="$(ModProfileDir)/BepInEx/plugins/FeralCompany-FeralCommon"
                Condition="Exists('$(ModProfileDir)') And !Exists('$(ModProfileDir)/BepInEx/plugins/FeralCompany-FeralCommon')"
        />
        <Exec Command="copy &quot;$(TargetPath)&quot; &quot;$(ModProfileDir)/BepInEx/plugins/FeralCompany-FeralCommon/&quot;"/>
    </Target>
</Project>
```

This file provides the necessary functionality:
-  `GameBaseDir`: The path to the game's installation directory.
    - Required for local builds to pull game DLLs.
- `ModProfileDir`: The path to the mod profile directory.
    - Required for local builds to pull dependencies
    - Copies the built DLL to the profile directory.
