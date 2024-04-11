using BepInEx;
using FeralCommon.Integrate;
using FeralCommon.Plugin;

namespace FeralCommon;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInDependency(Compat.LethalConfigKey, BepInDependency.DependencyFlags.SoftDependency)]
[BepInDependency(Compat.InputUtilsKey, BepInDependency.DependencyFlags.SoftDependency)]
internal class FeralCommonPlugin : FeralPlugin;
