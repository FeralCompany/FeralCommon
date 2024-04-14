using UnityEngine.InputSystem;

namespace FeralCommon.Input;

public interface IButtonFactory
{
    public ButtonPress CreateButtonPress(Key key, string actionId, string bindingName);
    public ButtonToggle CreateButtonToggle(Key key, string actionId, string bindingName, bool active = default);
}
