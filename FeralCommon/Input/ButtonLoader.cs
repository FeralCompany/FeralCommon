using System;
using System.Collections.Generic;
using System.Reflection;

namespace FeralCommon.Input;

public static class ButtonLoader
{
    private const BindingFlags AttributeFilter = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

    private static readonly Type ButtonPressType = typeof(ButtonPress);
    private static readonly Type ButtonToggleType = typeof(ButtonToggle);

    public static int RegisterAll(IButtonFactory factory, Type type)
    {
        GetConfigFields(type, out var presses, out var toggles);

        foreach (var wrapper in presses) RegisterPress(factory, wrapper);
        foreach (var wrapper in toggles) RegisterToggle(factory, wrapper);

        return presses.Count + toggles.Count;
    }

    private static void RegisterPress(IButtonFactory factory, ButtonPressWrapper wrapper)
    {
        var button = factory.CreateButtonPress(wrapper.Key, wrapper.ActionId, wrapper.BindingName);
        wrapper.Delegate = button;
    }

    private static void RegisterToggle(IButtonFactory factory, ButtonToggleWrapper wrapper)
    {
        var button = factory.CreateButtonToggle(wrapper.Key, wrapper.ActionId, wrapper.BindingName, wrapper.DefaultActive);
        wrapper.Delegate = button;
    }

    private static void GetConfigFields(Type from, out List<ButtonPressWrapper> presses, out List<ButtonToggleWrapper> toggles)
    {
        presses = [];
        toggles = [];

        foreach (var field in from.GetFields(AttributeFilter))
        {
            if (ButtonPressType.IsAssignableFrom(field.FieldType) && field.GetValue(null) is ButtonPressWrapper press)
            {
                presses.Add(press);
            }
            else if (ButtonToggleType.IsAssignableFrom(field.FieldType) && field.GetValue(null) is ButtonToggleWrapper toggle)
            {
                toggles.Add(toggle);
            }
        }

        foreach (var type in from.GetNestedTypes(AttributeFilter))
        {
            GetConfigFields(type, out var morePresses, out var moreToggles);
            presses.AddRange(morePresses);
            toggles.AddRange(moreToggles);
        }
    }
}
