namespace FeralCommon.Input;

public interface ILethalInput : IUnityInput
{
    public string ActionId { get; }
    public string BindingName { get; }
    public string KbmPath { get; }

    internal IActionContainer? Actions { get; set; }
}
