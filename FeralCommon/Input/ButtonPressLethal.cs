using FeralCommon.Extensions;
using LethalCompanyInputUtils.Api;
using UnityEngine.InputSystem;

namespace FeralCommon.Input;

internal class ButtonPressLethal(Key key, string actionId, string bindingName) : ButtonPress, ILethalInput
{
    public Key Key { get; } = key;
    public string ActionId { get; } = actionId;
    public string BindingName { get; } = bindingName;
    public string KbmPath { get; } = key.ToKbmPath();

    public IActionContainer? Actions { get; set; }

    public override bool PressedThisFrame()
    {
        return Actions?.GetAction(ActionId).triggered ?? Key.PressedThisFrame();
    }
}
