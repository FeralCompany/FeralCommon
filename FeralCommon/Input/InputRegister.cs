using System;
using System.Collections.Generic;
using BepInEx;
using FeralCommon.Utils;
using LethalCompanyInputUtils.Api;

namespace FeralCommon.Input;

internal class InputRegister(BepInPlugin plugin) // TODO: We are aware this param is unused. It will be used when LethalCompanyInputUtils updates.
{
    private readonly List<IButtonBinding> _buttons = [];

    private bool _registrationClosed;

    internal void RegisterButtons(Type type)
    {
        if (_registrationClosed) throw new InvalidOperationException("Cannot register buttons after registration has been closed");
        FieldSearcher.Search<IButtonBinding>(type, out var buttons);
        _buttons.AddRange(buttons);
    }

    internal void RegisterButtons(object instance)
    {
        if (_registrationClosed) throw new InvalidOperationException("Cannot register buttons after registration has been closed");
        FieldSearcher.Search<IButtonBinding>(instance, out var buttons);
        _buttons.AddRange(buttons);
    }

    internal void CompleteWorkAroundPartOne(in InputActionMapBuilder builder)
    {
        _registrationClosed = true;
        foreach (var button in _buttons)
            builder.NewActionBinding()
                .WithActionId(button.Id)
                .WithBindingName(button.Name)
                .WithKbmPath(button.Path)
                .WithKbmInteractions(button.Interaction)
                .Finish();
    }

    internal void CompleteWorkAroundPartTwo(LcInputActions binder)
    {
        foreach (var button in _buttons) button.Init(binder);
    }

    // TODO: Replace registration workaround with this method and class, when LethalCompanyInputUtils updates with our PR
    // internal void Complete()
    // {
    //     _registrationClosed = true;
    //     var binder = new LiteralRegister(plugin, _buttons);
    //
    //     foreach (var button in _buttons) button.Init(binder);
    // }
    // private class LiteralRegister(BepInPlugin plugin, List<IButtonBinding> buttons) : LcInputActions(plugin)
    // {
    //     public override void CreateInputActions(in InputActionMapBuilder builder)
    //     {
    //         foreach (var button in buttons)
    //         {
    //             builder.NewActionBinding()
    //                 .WithActionId(button.Id)
    //                 .WithBindingName(button.Name)
    //                 .WithKbmPath(button.Path)
    //                 .WithKbmInteractions(button.Interaction)
    //                 .Finish();
    //         }
    //     }
    // }
}
