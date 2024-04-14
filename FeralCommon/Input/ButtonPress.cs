using System.Diagnostics.CodeAnalysis;
using UnityEngine.InputSystem;

namespace FeralCommon.Input;

public abstract class ButtonPress
{
    [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
    public abstract bool PressedThisFrame();

    public static implicit operator bool(ButtonPress buttonPress)
    {
        return buttonPress.PressedThisFrame();
    }

    public static ButtonPress Create(Key key, string actionId, string bindingName)
    {
        return new ButtonPressWrapper(key, actionId, bindingName);
    }
}
