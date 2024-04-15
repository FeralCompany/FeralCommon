using BepInEx.Bootstrap;
using JetBrains.Annotations;

namespace FeralCommon.Utils;

public static class Compat
{
    public const string LethalConfigKey = "ainavt.lc.lethalconfig";
    public const string InputUtilsKey = "com.rune580.LethalCompanyInputUtils";

    [UsedImplicitly] public static bool LethalConfig => IsPluginAvailable(LethalConfigKey);

    [UsedImplicitly] public static bool InputUtils => IsPluginAvailable(InputUtilsKey);

    [UsedImplicitly]
    public static bool IsPluginAvailable(string key)
    {
        return Chainloader.PluginInfos.ContainsKey(key);
    }
}
