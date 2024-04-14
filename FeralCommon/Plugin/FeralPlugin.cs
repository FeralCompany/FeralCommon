using System;
using System.Diagnostics.CodeAnalysis;
using BepInEx;
using FeralCommon.Config;
using FeralCommon.Input;
using FeralCommon.Integrate;
using FeralCommon.Utils;
using UnityEngine;

namespace FeralCommon.Plugin;

public abstract class FeralPlugin : BaseUnityPlugin
{
    private IButtonFactory ButtonFactory { get; set; } = null!;

    private void Awake()
    {
        gameObject.hideFlags = HideFlags.HideAndDontSave;

        PrintLogo();

        Log.Info("Awake");

        ButtonFactory = Compat.InputUtils
            ? new ButtonFactoryLethal()
            : gameObject.AddComponent<ButtonFactoryUnity>();

        Load();

        // ReSharper disable once InvertIf
        if (ButtonFactory is ButtonFactoryLethal factory)
        {
            Log.Info("Detected LethalCompanyInputUtils, integrating...");
            factory.Activate();
        }
    }

    protected abstract void Load();

    private void Start()
    {
        Log.Info("Starting...");
        Enable();
    }

    protected abstract void Enable();

    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    protected void RegisterConfigs(Type type)
    {
        var count = ConfigLoader.ConfigureAll(Config, type);
        Log.Info($"Configured {count} fields found in {type.Name}");
    }

    protected void RegisterButtons(Type type)
    {
        var count = ButtonLoader.RegisterAll(ButtonFactory, type);
        Log.Info($"Registered {count} buttons found in {type.Name}");
    }

    private void PrintLogo()
    {
        if (this is FeralCommonPlugin)
        {
            Log.Info("""

                                   ______             _ _____
                                   |  ___|           | /  __ \
                                   | |_ ___ _ __ __ _| | /  \/ ___  _ __ ___  _ __   __ _ _ __  _   _
                                   |  _/ _ \ '__/ _` | | |    / _ \| '_ ` _ \| '_ \ / _` | '_ \| | | |
                                   | ||  __/ | | (_| | | \__/\ (_) | | | | | | |_) | (_| | | | | |_| |
                                   \_| \___|_|  \__,_|_|\____/\___/|_| |_| |_| .__/ \__,_|_| |_|\__, |
                                                                             | |                 __/ |
                                                                             |_|                |___/
                              """);
        }
    }
}
