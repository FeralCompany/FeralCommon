using System;
using FeralCommon.Config;
using LethalConfig;
using LethalConfig.ConfigItems;
using LethalConfig.ConfigItems.Options;

namespace FeralCommon.Integrate;

public static class LethalConfig
{
    public static void Register(IConfig raw)
    {
        var configItem = ToConfigItem(raw);
        LethalConfigManager.AddConfigItem(configItem);
    }

    private static BaseConfigItem ToConfigItem(IConfig raw)
    {
        return raw switch
        {
            IntConfig config => ToConfigItem(config),
            FloatConfig config => ToConfigItem(config),
            StringConfig config => ToConfigItem(config),
            _ => throw new ArgumentException($"Unsupported config type: {raw.GetType().Name}")
        };
    }

    private static IntSliderConfigItem ToConfigItem(IntConfig config)
    {
        return new IntSliderConfigItem(config.ConfigEntry, new IntSliderOptions
        {
            Min = config.Min,
            Max = config.Max,
            RequiresRestart = config.RequiresRestart
        });
    }

    private static FloatSliderConfigItem ToConfigItem(FloatConfig config)
    {
        return new FloatSliderConfigItem(config.ConfigEntry, new FloatStepSliderOptions
        {
            Min = config.Min,
            Max = config.Max,
            Step = config.Step,
            RequiresRestart = config.RequiresRestart
        });
    }

    private static TextInputFieldConfigItem ToConfigItem(StringConfig config)
    {
        return new TextInputFieldConfigItem(config.ConfigEntry, new TextInputFieldOptions
        {
            RequiresRestart = config.RequiresRestart,
            CharacterLimit = config.CharacterLimit,
            NumberOfLines = config.NumberOfLines,
            TrimText = config.TrimText
        });
    }
}
