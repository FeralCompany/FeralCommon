using LethalCompanyInputUtils.Api;

namespace FeralCommon.Input;

internal interface IButtonBinding
{
    internal string Id { get; }
    internal string Name { get; }
    internal string Path { get; }
    internal string? Interaction { get; }

    internal void Init(LcInputActions binder);
}
