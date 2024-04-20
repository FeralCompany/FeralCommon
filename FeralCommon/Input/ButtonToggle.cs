using System;
using JetBrains.Annotations;

namespace FeralCommon.Input;

[UsedImplicitly]
public class ButtonToggle(string id, string name, string path, bool activeByDefault = false) : ButtonBindingBase<ButtonToggle>(id, name, path)
{
    [UsedImplicitly] public bool Active { get; private set; } = activeByDefault;

    private Action<bool>? WhenToggled { get; set; }

    [UsedImplicitly]
    public ButtonToggle OnToggle(Action<bool> action)
    {
        WhenToggled += action;
        return this;
    }

    protected override void Init()
    {
        Input.performed += _ =>
        {
            Active = !Active;
            WhenToggled?.Invoke(Active);
        };
    }

    public static implicit operator bool(ButtonToggle toggle)
    {
        return toggle.Active;
    }
}
