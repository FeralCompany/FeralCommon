using BepInEx.Configuration;
using LethalConfig.ConfigItems;

namespace FeralCommon.Config;

public abstract class ConfigBase
{
    internal abstract void InitConfigEntry(ConfigFile configFile);
    protected internal abstract BaseConfigItem CreateConfigItem();
}
