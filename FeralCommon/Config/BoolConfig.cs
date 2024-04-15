using JetBrains.Annotations;
using LethalConfig.ConfigItems;
using LethalConfig.ConfigItems.Options;

namespace FeralCommon.Config;

[UsedImplicitly]
public class BoolConfig(string section, string key) : Config<BoolConfig, bool>(section, key)
{
    protected internal override BaseConfigItem CreateConfigItem()
    {
        var options = new BoolCheckBoxOptions();
        return new BoolCheckBoxConfigItem(ValidatedEntry, FillBaseOptions(options));
    }
}
