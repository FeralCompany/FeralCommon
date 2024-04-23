using System.Reflection;
using HarmonyLib;
using JetBrains.Annotations;

namespace FeralCommon.Utils.Extensions;

public static class HarmonyExtension
{
    [UsedImplicitly]
    public static void PatchNamespace(this Harmony harmony, string namespaceStr)
    {
        foreach (var type in Assembly.GetCallingAssembly().GetTypes())
            if (type.Namespace != null && type.Namespace == namespaceStr)
                harmony.PatchAll(type);
    }
}
