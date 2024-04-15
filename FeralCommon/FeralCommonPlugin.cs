using BepInEx;
using FeralCommon.Utils;

namespace FeralCommon;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInDependency(Compat.LethalConfigKey)]
[BepInDependency(Compat.InputUtilsKey)]
public class FeralCommonPlugin : FeralPlugin;
