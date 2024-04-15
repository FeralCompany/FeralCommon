using System;
using JetBrains.Annotations;

namespace FeralCommon.Input;

[UsedImplicitly]
public class ButtonPress(string id, string name, string path) : ButtonBindingBase<ButtonPress>(id, name, path)
{
    [UsedImplicitly] public bool PressedThisFrame => Input.triggered;

    private Action? WhenPressed { get; set; }

    [UsedImplicitly]
    public ButtonPress OnPressed(Action whenPressed)
    {
        WhenPressed += whenPressed;
        return this;
    }

    protected override void Init()
    {
        Input.performed += _ => WhenPressed?.Invoke();
    }

    public static implicit operator bool(ButtonPress press)
    {
        return press.PressedThisFrame;
    }
}
