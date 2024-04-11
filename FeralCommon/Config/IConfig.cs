using BepInEx.Configuration;

namespace FeralCommon.Config;

public interface IConfig
{
    void InitConfigEntry(ConfigFile configFile);
}
