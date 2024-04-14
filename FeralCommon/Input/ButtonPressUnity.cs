using FeralCommon.Extensions;
using UnityEngine.InputSystem;

namespace FeralCommon.Input;

internal class ButtonPressUnity(Key key) : ButtonPress, IUnityInput
{

    public Key Key { get; } = key;

    public override bool PressedThisFrame()
    {
        return Key.PressedThisFrame();
    }
}
