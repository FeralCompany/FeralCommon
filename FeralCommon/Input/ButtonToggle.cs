using UnityEngine.InputSystem;

namespace FeralCommon.Input;

public abstract class ButtonToggle : ButtonPress
{
    public abstract bool IsActive();
    public abstract void ToggleActive();
    public abstract void SetActive(bool active);

    public static implicit operator bool(ButtonToggle buttonToggle)
    {
        return buttonToggle.IsActive();
    }

    public static ButtonToggle Create(Key key, string actionId, string bindingName, bool active = default)
    {
        return new ButtonToggleWrapper(key, actionId, bindingName, active);
    }
}
