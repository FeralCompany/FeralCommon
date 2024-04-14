using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using BepInEx;

namespace FeralCommon.Extensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
internal static class AssemblyExtensions
{
    public static BepInPlugin GetBepInPlugin(this Assembly assembly)
    {
        foreach (var validType in assembly.GetValidTypes())
        {
            var customAttribute = validType.GetCustomAttribute<BepInPlugin>();
            if (customAttribute != null)
            {
                return customAttribute;
            }
        }
        throw new Exception("No BepInPlugin attribute found in assembly.");
    }

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
