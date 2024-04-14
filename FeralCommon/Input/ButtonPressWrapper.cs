using System;
using UnityEngine.InputSystem;

namespace FeralCommon.Input;

internal class ButtonPressWrapper(Key key, string actionId, string bindingName) : ButtonPress
{
    internal Key Key { get; } = key;
    internal string ActionId { get; } = actionId;
    internal string BindingName { get; } = bindingName;

    internal ButtonPress? Delegate { get; set; }

    public override bool PressedThisFrame()
    {
        ValidateDelegate();
        return Delegate!.PressedThisFrame();
    }

    private void ValidateDelegate()
    {
        if (Delegate is null)
        {
            throw new NullReferenceException($"ButtonToggle with actionId '{ActionId}' has not been registered");
        }
    }
}
