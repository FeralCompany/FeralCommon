using GameNetcodeStuff;

namespace FeralCommon.Utils;

public static class PlayerUtil
{
    public static PlayerControllerB LocalPlayer()
    {
        return GameNetworkManager.Instance.localPlayerController;
    }

    public static bool IsLocalPlayer(PlayerControllerB controller)
    {
        return LocalPlayer() == controller;
    }
}
