using System;
using JetBrains.Annotations;
using LethalCompanyInputUtils.Api;
using UnityEngine.InputSystem;

namespace FeralCommon.Input;

public abstract class ButtonBindingBase<TDerived>(string id, string name, string path) : IButtonBinding where TDerived : ButtonBindingBase<TDerived>
{
    private string Id { get; } = id;
    private string Name { get; } = name;
    private string Path { get; } = path;

    [UsedImplicitly] protected InputAction Input => Binder?.Asset.FindAction(Id) ?? throw new InvalidOperationException("Binder not initialized");

    private LcInputActions? Binder { get; set; }

    private string? Interaction { get; set; }

    string IButtonBinding.Id => Id;
    string IButtonBinding.Name => Name;
    string IButtonBinding.Path => Path;
    string? IButtonBinding.Interaction => Interaction;

    void IButtonBinding.Init(LcInputActions binder)
    {
        Binder = binder;
        Init();
    }

    [UsedImplicitly]
    public TDerived WithInteraction(string interaction)
    {
        Interaction = interaction;
        return (TDerived)this;
    }

    protected abstract void Init();
}
