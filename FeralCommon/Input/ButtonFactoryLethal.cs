using System.Collections.Generic;
using FeralCommon.Utils;
using LethalCompanyInputUtils.Api;
using UnityEngine.InputSystem;

namespace FeralCommon.Input;

internal class ButtonFactoryLethal : IButtonFactory
{
    private List<ILethalInput> Inputs { get; } = [];

    public ButtonPress CreateButtonPress(Key key, string actionId, string bindingName)
    {
        var input = new ButtonPressLethal(key, actionId, bindingName);
        Inputs.Add(input);
        return input;
    }

    public ButtonToggle CreateButtonToggle(Key key, string actionId, string bindingName, bool active = default)
    {
        var input = new ButtonToggleLethal(key, actionId, bindingName, active);
        Inputs.Add(input);
        return input;
    }

    internal void Activate()
    {
        var actions = new LcInputActionsImpl(Inputs);
        foreach (var input in Inputs)
        {
            if (input is ButtonToggleLethal toggle)
            {
                actions.Asset[input.ActionId].performed += _ => toggle.ToggleActive();
            }
        }
    }

    private class LcInputActionsImpl(List<ILethalInput> inputs) : LcInputActions, IActionContainer
    {
        public override void CreateInputActions(in InputActionMapBuilder builder)
        {
            foreach (var input in inputs)
            {
                Log.Info($"Registering input action {input.ActionId} with binding {input.BindingName}");
                builder.NewActionBinding()
                    .WithActionId(input.ActionId)
                    .WithActionType(InputActionType.Button)
                    .WithBindingName(input.BindingName)
                    .WithKbmPath(input.KbmPath)
                    .Finish();

                input.Actions = this;
            }
        }

        public InputAction GetAction(string actionId)
        {
            return Asset[actionId];
        }
    }
}
