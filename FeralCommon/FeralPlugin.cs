using System;
using System.Collections.Generic;
using System.Reflection;
using BepInEx;
using FeralCommon.Config;
using FeralCommon.Input;
using FeralCommon.Utils;
using HarmonyLib;
using JetBrains.Annotations;
using LethalCompanyInputUtils.Api;
using LethalConfig;
using UnityEngine;

namespace FeralCommon;

[UsedImplicitly]
public abstract class FeralPlugin : BaseUnityPlugin
{
    private Harmony? _harmony;

    private InputRegister? _inputRegister;

    [UsedImplicitly] public Harmony Harmony => _harmony ??= new Harmony(MyPluginInfo.PLUGIN_GUID);

    private void Awake()
    {
        gameObject.hideFlags = HideFlags.HideAndDontSave;

        _inputRegister = new InputRegister(Info.Metadata);

        Load();
    }

    public void CompleteWorkAroundPartOne(in InputActionMapBuilder builder)
    {
        _inputRegister!.CompleteWorkAroundPartOne(builder);
    }

    public void CompleteWorkAroundPartTwo(LcInputActions binder)
    {
        _inputRegister!.CompleteWorkAroundPartTwo(binder);
    }

    [UsedImplicitly]
    protected virtual void Load()
    {
    }

    [UsedImplicitly]
    protected void RegisterConfigs(Type type)
    {
        FieldSearcher.Search<ConfigBase>(type, out var configs);
        RegisterConfigs(configs, Assembly.GetCallingAssembly());
    }

    [UsedImplicitly]
    protected void RegisterConfigs(object instance)
    {
        FieldSearcher.Search<ConfigBase>(instance, out var configs);
        RegisterConfigs(configs, Assembly.GetCallingAssembly());
    }

    [UsedImplicitly]
    protected void RegisterButtons(Type type)
    {
        _inputRegister!.RegisterButtons(type);
    }

    [UsedImplicitly]
    protected void RegisterButtons(object instance)
    {
        _inputRegister!.RegisterButtons(instance);
    }

    private void RegisterConfigs(List<ConfigBase> configs, Assembly assembly)
    {
        foreach (var config in configs)
        {
            config.InitConfigEntry(Config);

            LethalConfigManager.AddConfigItem(config.CreateConfigItem(), assembly);
        }
    }
}
