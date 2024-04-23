using System;
using JetBrains.Annotations;
using LethalConfig.ConfigItems;
using LethalConfig.ConfigItems.Options;

namespace FeralCommon.Config;

[UsedImplicitly]
public class EnumConfig<TEnum>(string section, string key) : Config<EnumConfig<TEnum>, TEnum>(section, key) where TEnum : Enum
{
    protected internal override BaseConfigItem CreateConfigItem()
    {
        return new EnumDropDownConfigItem<TEnum>(ValidatedEntry, FillBaseOptions(new EnumDropDownOptions()));
    }
}
