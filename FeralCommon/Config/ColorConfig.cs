using JetBrains.Annotations;
using LethalConfig.ConfigItems;
using LethalConfig.ConfigItems.Options;
using UnityEngine;

namespace FeralCommon.Config;

[UsedImplicitly]
public class ColorConfig(string section, string key) : Config<ColorConfig, string>(section, key)
{
    [UsedImplicitly]
    public Color GetColor()
    {
        return ColorUtility.TryParseHtmlString(this, out var color) ? color : Color.white;
    }

    protected internal override BaseConfigItem CreateConfigItem()
    {
        var options = new TextInputFieldOptions { CharacterLimit = 7 };
        return new TextInputFieldConfigItem(ValidatedEntry, FillBaseOptions(options));
    }

    public static implicit operator Color(ColorConfig config)
    {
        return config.GetColor();
    }
}
