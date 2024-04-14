using System;
using UnityEngine.InputSystem;

namespace FeralCommon.Input;

internal class ButtonToggleWrapper(Key key, string actionId, string bindingName, bool defaultActive = default) : ButtonToggle
{
    internal Key Key { get; } = key;
    internal string ActionId { get; } = actionId;
    internal string BindingName { get; } = bindingName;
    internal bool DefaultActive { get; private set; } = defaultActive;

    internal ButtonToggle? Delegate { get; set; }

    public override bool PressedThisFrame()
    {
        ValidateDelegate();
        return Delegate!.PressedThisFrame();
    }

    public override bool IsActive()
    {
        ValidateDelegate();
        return Delegate!.IsActive();
    }

    public override void ToggleActive()
    {
        ValidateDelegate();
        Delegate!.ToggleActive();
    }

    public override void SetActive(bool active)
    {
        ValidateDelegate();
        Delegate!.SetActive(active);
    }

    private void ValidateDelegate()
    {
        if (Delegate is null)
        {
            throw new NullReferenceException($"ButtonToggle with actionId '{ActionId}' has not been registered");
        }
    }
}
