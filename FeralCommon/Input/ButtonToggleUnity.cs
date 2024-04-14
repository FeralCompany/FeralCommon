using FeralCommon.Extensions;
using UnityEngine.InputSystem;

namespace FeralCommon.Input;

internal class ButtonToggleUnity(Key key, bool active = default) : ButtonToggle, IUnityInput
{
    public Key Key { get; } = key;

    private bool Active { get; set; } = active;

    public override bool PressedThisFrame()
    {
        return Key.PressedThisFrame();
    }

    internal void Update()
    {
        if (Key.PressedThisFrame())
        {
            Active = !Active;
        }
    }

    public override bool IsActive()
    {
        return Active;
    }

    public override void ToggleActive()
    {
        Active = !Active;
    }

    public override void SetActive(bool active)
    {
        Active = active;
    }
}
