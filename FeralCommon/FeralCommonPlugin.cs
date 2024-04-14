using BepInEx;
using FeralCommon.Input;
using FeralCommon.Integrate;
using FeralCommon.Plugin;
using FeralCommon.Utils;
using UnityEngine.InputSystem;

namespace FeralCommon;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInDependency(Compat.LethalConfigKey, BepInDependency.DependencyFlags.SoftDependency)]
[BepInDependency(Compat.InputUtilsKey, BepInDependency.DependencyFlags.SoftDependency)]
public class FeralCommonPlugin : FeralPlugin
{

    private static readonly ButtonPress ButtonPress = ButtonPress.Create(Key.F, "ButtonPressTest", "ButtonPressTest");
    private static readonly ButtonToggle ButtonToggle = ButtonToggle.Create(Key.T, "ButtonToggleTest", "ButtonToggleTest");

    protected override void Load()
    {
        RegisterButtons(typeof(FeralCommonPlugin));
    }

    protected override void Enable()
    {
        Log.Info("FeralCommonPlugin Enabled");
    }

    private void Update()
    {
        Log.Info(ButtonPress ? "Press: YES" : "Press: NO");
        Log.Info(ButtonToggle ? "Toggle: YES" : "Toggle: NO");
    }
}
