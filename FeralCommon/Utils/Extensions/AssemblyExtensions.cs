using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BepInEx;
using JetBrains.Annotations;

namespace FeralCommon.Utils.Extensions;

public static class AssemblyExtensions
{
    [UsedImplicitly]
    public static BepInPlugin GetBepInPlugin(this Assembly assembly)
    {
        foreach (var validType in assembly.GetValidTypes())
        {
            var customAttribute = validType.GetCustomAttribute<BepInPlugin>();
            if (customAttribute != null) return customAttribute;
        }

        throw new Exception("No BepInPlugin attribute found in assembly.");
    }

    [UsedImplicitly]
    public static IEnumerable<Type> GetValidTypes(this Assembly assembly)
    {
        try
        {
            return assembly.GetTypes();
        }
        catch (ReflectionTypeLoadException ex)
        {
            return ex.Types.Where<Type>((Func<Type, bool>)(type => type != null));
        }
    }
}
