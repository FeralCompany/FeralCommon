using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FeralCommon.Input;

internal class ButtonFactoryUnity : MonoBehaviour, IButtonFactory
{
    private readonly List<ButtonToggleUnity> _toggles = [];

    public ButtonPress CreateButtonPress(Key key, string actionId, string bindingName)
    {
        return new ButtonPressUnity(key);
    }

    public ButtonToggle CreateButtonToggle(Key key, string actionId, string bindingName, bool active = default)
    {
        var toggle = new ButtonToggleUnity(key, active);
        _toggles.Add(toggle);
        return toggle;
    }

    public void Update()
    {
        foreach (var toggle in _toggles)
        {
            toggle.Update();
        }
    }
}
