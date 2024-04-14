using FeralCommon.Extensions;
using UnityEngine.InputSystem;

namespace FeralCommon.Input;

internal class ButtonToggleLethal(Key key, string actionId, string bindingName, bool active = default) : ButtonToggle, ILethalInput
{
    public Key Key { get; } = key;
    public string ActionId { get; } = actionId;
    public string BindingName { get; } = bindingName;
    public string KbmPath { get; } = key.ToKbmPath();

    private bool Active { get; set; } = active;

    public IActionContainer? Actions { get; set; }

    public override bool PressedThisFrame()
    {
        return Actions?.GetAction(ActionId).triggered ?? Key.PressedThisFrame();
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
