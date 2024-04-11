using System.Diagnostics.CodeAnalysis;
using BepInEx.Logging;

namespace FeralCommon.Log;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public class Logger(ManualLogSource logger)
{
    public void Debug(object data)
    {
        logger.LogDebug(data);
    }

    public void Info(object data)
    {
        logger.LogInfo(data);
    }

    public void Warning(object data)
    {
        logger.LogWarning(data);
    }

    public void Error(object data)
    {
        logger.LogError(data);
    }

    public void Fatal(object data)
    {
        logger.LogFatal(data);
    }
}
