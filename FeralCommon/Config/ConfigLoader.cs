using System;
using System.Collections.Generic;
using System.Reflection;
using BepInEx.Configuration;
using FeralCommon.Integrate;

namespace FeralCommon.Config;

internal static class ConfigLoader
{
    private static readonly Type ConfigType = typeof(IConfig);

    public static int ConfigureAll(ConfigFile configFile, Type from)
    {
        var discovered = new List<IConfig>();
        GetConfigFields(from, discovered);

        foreach (var config in discovered)
        {
            config.InitConfigEntry(configFile);
            if (Compat.LethalConfig) Integrate.LethalConfig.Register(config);
        }

        return discovered.Count;
    }

    private static void GetConfigFields(Type from, ICollection<IConfig> discovered)
    {
        var fields = from.GetFields(BindingFlags.Public | BindingFlags.Static);
        foreach (var field in fields)
            if (ConfigType.IsAssignableFrom(field.FieldType) && field.GetValue(null) is IConfig config)
                discovered.Add(config);

        var nested = from.GetNestedTypes(BindingFlags.Public | BindingFlags.Static);
        foreach (var type in nested) GetConfigFields(type, discovered);
    }
}
