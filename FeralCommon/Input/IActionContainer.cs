using UnityEngine.InputSystem;

namespace FeralCommon.Input;

public interface IActionContainer
{
    public InputAction GetAction(string actionId);
}
