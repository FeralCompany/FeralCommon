using System;
using System.Collections.Generic;
using System.Reflection;
using BepInEx.Configuration;
using FeralCommon.Integrate;

namespace FeralCommon.Config;

internal static class ConfigLoader
{
    private const BindingFlags AttributeFilter = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

    private static readonly Type ConfigType = typeof(IConfig);

    public static int ConfigureAll(ConfigFile configFile, Type from)
    {
        GetConfigFields(from, out var configs);
        foreach (var config in configs)
        {
            config.InitConfigEntry(configFile);
            if (Compat.LethalConfig) Integrate.LethalConfig.Register(config);
        }

        return configs.Count;
    }

    private static void GetConfigFields(Type from, out List<IConfig> configs)
    {
        configs = [];

        foreach (var field in from.GetFields(AttributeFilter))
        {
            if (ConfigType.IsAssignableFrom(field.FieldType) && field.GetValue(null) is IConfig config)
            {
                configs.Add(config);
            }
        }

        foreach (var type in from.GetNestedTypes(AttributeFilter))
        {
            GetConfigFields(type, out var moreConfigs);
            configs.AddRange(moreConfigs);
        }
    }
}
