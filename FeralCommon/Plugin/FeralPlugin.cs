using System;
using System.Diagnostics.CodeAnalysis;
using BepInEx;
using FeralCommon.Config;
using FeralCommon.Log;

namespace FeralCommon.Plugin;

public abstract class FeralPlugin : BaseUnityPlugin
{
    // ReSharper disable once MemberCanBePrivate.Global
    public new readonly Logger Logger;

    protected FeralPlugin()
    {
        Logger = LoggerFactory.GetLogger(GetType());
    }

    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    protected void ConfigureAll(Type type)
    {
        var count = ConfigLoader.ConfigureAll(Config, type);
        Logger.Info($"Configured {count} fields found in {type.Name}");
    }
}
