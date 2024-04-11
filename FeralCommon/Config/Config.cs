using System;
using System.Diagnostics.CodeAnalysis;
using BepInEx.Configuration;

namespace FeralCommon.Config;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public abstract class Config<TDerived, TType> : IConfig where TDerived : Config<TDerived, TType> where TType : IComparable
{
    private string Section { get; set; } = string.Empty;
    private string Key { get; set; } = string.Empty;
    private string Description { get; set; } = "No description provided";
    private TType? DefaultValue { get; set; }

    internal bool RequiresRestart { get; private set; }

    internal ConfigEntry<TType>? ConfigEntry { get; private set; }

    public void InitConfigEntry(ConfigFile configFile)
    {
        if (Section == string.Empty || Key == string.Empty)
            throw new InvalidOperationException("Section and Key must be set before initializing config entry.");

        if (DefaultValue == null) throw new InvalidOperationException("Default value must be set before initializing config entry.");

        var definition = new ConfigDefinition(Section, Key);
        var description = new ConfigDescription(Description, CreateAcceptableValue());
        var entry = configFile.Bind(definition, DefaultValue, description);
        ConfigEntry = entry;
    }

    public TDerived WithDefinition(string section, string key)
    {
        Section = section;
        Key = key;
        return (TDerived)this;
    }

    public TDerived WithDescription(string description)
    {
        Description = description;
        return (TDerived)this;
    }

    public TDerived WithDefaultValue(TType defaultValue)
    {
        DefaultValue = defaultValue;
        return (TDerived)this;
    }

    public TDerived SetRequiresRestart()
    {
        RequiresRestart = true;
        return (TDerived)this;
    }

    protected virtual AcceptableValueBase? CreateAcceptableValue()
    {
        return null;
    }
}
