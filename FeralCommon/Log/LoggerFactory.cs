using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FeralCommon.Log;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static class LoggerFactory
{
    private static readonly Dictionary<Type, Logger> Loggers = new();

    public static Logger GetLogger<TType>()
    {
        return GetLogger(typeof(TType));
    }

    public static Logger GetLogger(Type type)
    {
        if (Loggers.TryGetValue(type, out var found)) return found;

        Logger logger = new(BepInEx.Logging.Logger.CreateLogSource(type.Name));
        Loggers[type] = logger;
        return logger;
    }
}
