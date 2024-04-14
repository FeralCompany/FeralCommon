using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using BepInEx.Logging;

namespace FeralCommon.Utils;

public static class Log
{
    private const string LogTemplate = "{0}#{1}(L{2}): {3}";
    private static readonly Dictionary<string, ManualLogSource> Loggers = new();

    public static void Debug(string message,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "",
        [CallerLineNumber] int lineNumber = 0)
    {
        var logger = GetLogSource(Assembly.GetCallingAssembly());
        LogInternal(logger, LogLevel.Debug, message, filePath, memberName, lineNumber);
    }

    public static void Info(string message,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "",
        [CallerLineNumber] int lineNumber = 0)
    {
        var logger = GetLogSource(Assembly.GetCallingAssembly());
        LogInternal(logger, LogLevel.Info, message, filePath, memberName, lineNumber);
    }

    public static void Warning(string message,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "",
        [CallerLineNumber] int lineNumber = 0)
    {
        var logger = GetLogSource(Assembly.GetCallingAssembly());
        LogInternal(logger, LogLevel.Warning, message, filePath, memberName, lineNumber);
    }

    public static void Error(string message,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "",
        [CallerLineNumber] int lineNumber = 0)
    {
        var logger = GetLogSource(Assembly.GetCallingAssembly());
        LogInternal(logger, LogLevel.Error, message, filePath, memberName, lineNumber);
    }

    public static void Fatal(string message,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "",
        [CallerLineNumber] int lineNumber = 0)
    {
        var logger = GetLogSource(Assembly.GetCallingAssembly());
        LogInternal(logger, LogLevel.Fatal, message, filePath, memberName, lineNumber);
    }

    private static void LogInternal(ManualLogSource logger, LogLevel level, string message, string filePath, string memberName, int lineNumber)
    {
        var fileName = filePath[(filePath.LastIndexOf('\\') + 1)..].Replace(".cs", "");
        logger.Log(level, string.Format(LogTemplate, fileName, memberName, lineNumber, message));
    }

    private static ManualLogSource GetLogSource(Assembly assembly)
    {
        var name = assembly.GetName().Name;
        if (string.IsNullOrWhiteSpace(name)) throw new NullReferenceException("Assembly name is null or empty");
        if (Loggers.TryGetValue(name, out var source)) return source;
        return Loggers[name] = Logger.CreateLogSource(name);
    }
}
