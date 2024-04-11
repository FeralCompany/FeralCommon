using System.Diagnostics.CodeAnalysis;
using BepInEx.Bootstrap;

namespace FeralCommon.Integrate;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static class Compat
{
    public const string LethalConfigKey = "ainavt.lc.lethalconfig";
    public const string InputUtilsKey = "com.rune580.LethalCompanyInputUtils";

    public static bool LethalConfig => IsPluginAvailable(LethalConfigKey);
    public static bool InputUtils => IsPluginAvailable(InputUtilsKey);

    private static bool IsPluginAvailable(string key)
    {
        return Chainloader.PluginInfos.ContainsKey(key);
    }
}
