# FeralCommon

[![Build](https://img.shields.io/github/actions/workflow/status/FeralCompany/FeralCommon/build.yml?branch=main&style=for-the-badge&logo=github)](https://github.com/FeralCompany/FeralCommon/actions/workflows/build.yml)
[![Latest Version](https://img.shields.io/thunderstore/v/FeralCompany/FeralCommon?style=for-the-badge&logo=thunderstore)](https://thunderstore.io/c/lethal-company/p/FeralCompany/FeralCommon)
[![Total Downloads](https://img.shields.io/thunderstore/dt/FeralCompany/FeralCommon?style=for-the-badge&logo=thunderstore)](https://thunderstore.io/c/lethal-company/p/FeralCompany/FeralCommon)

This is a collection of common utilities and classes that are used across various FeralCompany projects.

## Contributing

Please read the [contribution guidelines](CONTRIBUTING.md) before submitting a pull request. These guidelines will also help you set up
your development environment.

## Usage

### Reference

```xml
<!-- Accessible via nuget source: https://nuget.windows10ce.com/nuget/v3/index.json -->
<!-- Thanks to Aaron Robinson for their efforts turning Thunderstore into a DLL repository -->
<!-- Do note, however, that updates are not propagated immediately. -->
<!-- See contribution guidelines for instructions on building this resource locally. -->
<PackageReference Include="FeralCompany-FeralCommon" Version="<Version>" PrivateAssets="all"/>
```

### Buttons

Buttons are extremely simplified and abstracted InputActions, integrated with [InputUtils][InputUtils].

#### Definition

```csharp
// This class is used to define a button and a toggle that can be used in the game.
public static class Buttons
{
    public static ButtonPress PressTest { get; } = new("pressTest", "Test Button Press", "<keyboard>/f");
    public static ButtonToggle ToggleTest { get; } = new("toggleTest", "Test Button Toggle", "<keyboard>/t");
}
```

#### Event Listener

```csharp
public void Awake() {
    Buttons.PressTest.OnPressed(() => {
        // This will be called when the button is pressed.
    });
    Buttons.ToggleTest.OnToggle(state => {
        // This will be called whenever the button is toggled.
        if (state) {
            // This will be called when the button is toggled ON.
        } else {
            // This will be called when the button is toggled OFF.
        }
    });
}
```

#### Direct / Implicit Access

```csharp
public void Update() {
    if (Buttons.PressTest) {
        // This will be true for a single frame when the button is pressed.
    }
    if (Buttons.ToggleTest) {
        // This will be true (or false) until the button is pressed again.
    }
}
```

#### Registration

```csharp
public void Load() {
    RegisterButtons(typeof(MyButtons)); // Will only register static fields.
    RegisterButtons(new MyButtons()); // Will only register instance fields.
}
```

Note: RegisterButtons is a protected method in the `FeralPlugin` class.

### Configs

Configs are extremely simplified and abstracted ConfigEntries, integrated with [LethalConfig][LethalConfig].

#### Definition

```csharp
public static class MyConfigs {
    public static readonly FloatConfig SomeFloat = new FloatConfig("Settings", "SomeFloat")
            .WithDescription("Some Description")
            .WithDefaultValue(0.5F)
            .WithMin(0F)
            .WithMax(1F)
            .WithStep(0.001F);
}
```

#### Event Listener

```csharp
public static void Awake() {
    MyConfigs.SomeFloat.OnValueChanged(newValue => {
        // This will be called whenever the value is changed.
    });
}
```

#### Direct / Implicit Access

```csharp
public static void Update() {
    if (MyConfigs.SomeFloat <= 0.5F) {
        // This will be true if the value is less than or equal to 0.5.
    }
}
```

#### Registration

```csharp
public void Load() {
    RegisterConfigs(typeof(MyConfigs)); // Will only register static fields.
    RegisterConfigs(new MyConfigs()); // Will only register instance fields.
}
```

[InputUtils]: <https://thunderstore.io/c/lethal-company/p/Rune580/LethalCompany_InputUtils/> "InputUtils by Rune580"

[LethalConfig]: <https://thunderstore.io/c/lethal-company/p/AinaVT/LethalConfig/> "LethalConfig by AinaVT"
