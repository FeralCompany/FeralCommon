using System;
using System.Collections.Generic;
using System.Linq;
using BepInEx.Configuration;
using JetBrains.Annotations;
using LethalConfig.ConfigItems.Options;

namespace FeralCommon.Config;

public abstract class Config<TDerived, TType>(string section, string key)
    : ConfigBase where TDerived : Config<TDerived, TType> where TType : IConvertible
{
    private string Section { get; } = section;
    private string Key { get; } = key;

    private string Description { get; set; } = "No description provided.";
    private TType? DefaultValue { get; set; }
    private bool RequiresRestart { get; set; }
    private List<Action<TType>> ValueChangedActions { get; } = [];
    private List<Func<CanModifyResult>> CanModifyChecks { get; } = [];

    private ConfigEntry<TType>? Entry { get; set; }

    protected ConfigEntry<TType> ValidatedEntry =>
        Entry ?? throw new InvalidOperationException("Config entry must be initialized before getting value.");

    [UsedImplicitly] public TType Value => ValidatedEntry.Value;

    [UsedImplicitly]
    public TDerived WithDescription(string description)
    {
        Description = description;
        return (TDerived)this;
    }

    [UsedImplicitly]
    public TDerived WithDefaultValue(TType defaultValue)
    {
        DefaultValue = defaultValue;
        return (TDerived)this;
    }

    [UsedImplicitly]
    public TDerived SetRequiresRestart()
    {
        RequiresRestart = true;
        return (TDerived)this;
    }

    [UsedImplicitly]
    public TDerived OnValueChanged(Action<TType> action)
    {
        ValueChangedActions.Add(action);
        return (TDerived)this;
    }

    [UsedImplicitly]
    public TDerived CanModify(Func<CanModifyResult> check)
    {
        CanModifyChecks.Add(check);
        return (TDerived)this;
    }

    private CanModifyResult CanModifyValue()
    {
        if (CanModifyChecks.Count == 0) return CanModifyResult.True();

        var reasons = CanModifyChecks
            .Select(check => check.Invoke())
            .Where(result => !result)
            .Select(result => result.Reason)
            .ToList();

        return reasons.Any() ? CanModifyResult.False(string.Join(Environment.NewLine, reasons)) : CanModifyResult.True();
    }

    internal override void InitConfigEntry(ConfigFile configFile)
    {
        if (DefaultValue == null) throw new InvalidOperationException("Default value must be set before initializing config entry.");

        var definition = new ConfigDefinition(Section, Key);
        var description = new ConfigDescription(Description, CreateAcceptableValue());

        var entry = configFile.Bind(definition, DefaultValue, description);
        entry.SettingChanged += (_, _) =>
        {
            var value = entry.Value;
            ValueChangedActions.ForEach(e => e.Invoke(value));
        };

        Entry = entry;
    }

    protected virtual AcceptableValueBase? CreateAcceptableValue()
    {
        return null;
    }

    protected TBaseOptions FillBaseOptions<TBaseOptions>(TBaseOptions options) where TBaseOptions : BaseOptions
    {
        options.Section = Section;
        options.Name = Key;
        options.Description = Description;
        options.RequiresRestart = RequiresRestart;
        options.CanModifyCallback = CanModifyValue;
        return options;
    }

    public static implicit operator TType(Config<TDerived, TType> config)
    {
        return config.Value;
    }
}
