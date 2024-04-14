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
            BoolConfig config => ToConfigItem(config),
            IntConfig config => ToConfigItem(config),
            FloatConfig config => ToConfigItem(config),
            StringConfig config => ToConfigItem(config),
            ColorConfig config => ToConfigItem(config),
            _ => throw new ArgumentException($"Unsupported config type: {raw.GetType().Name}")
        };
    }

    private static BoolCheckBoxConfigItem ToConfigItem(BoolConfig config)
    {
        return new BoolCheckBoxConfigItem(config, new BoolCheckBoxOptions
        {
            RequiresRestart = config.RequiresRestart
        });
    }

    private static IntSliderConfigItem ToConfigItem(IntConfig config)
    {
        return new IntSliderConfigItem(config, new IntSliderOptions
        {
            Min = config.Min,
            Max = config.Max,
            RequiresRestart = config.RequiresRestart
        });
    }

    private static FloatSliderConfigItem ToConfigItem(FloatConfig config)
    {
        return new FloatSliderConfigItem(config, new FloatStepSliderOptions
        {
            Min = config.Min,
            Max = config.Max,
            Step = config.Step,
            RequiresRestart = config.RequiresRestart
        });
    }

    private static TextInputFieldConfigItem ToConfigItem(StringConfig config)
    {
        return new TextInputFieldConfigItem(config, new TextInputFieldOptions
        {
            RequiresRestart = config.RequiresRestart,
            CharacterLimit = config.CharacterLimit,
            NumberOfLines = config.NumberOfLines,
            TrimText = config.TrimText
        });
    }

    private static TextInputFieldConfigItem ToConfigItem(ColorConfig config)
    {
        return new TextInputFieldConfigItem(config, new TextInputFieldOptions
        {
            RequiresRestart = config.RequiresRestart,
            CharacterLimit = 7,
            NumberOfLines = 1,
            TrimText = true
        });
    }
}
