using GameNetcodeStuff;
using JetBrains.Annotations;

namespace FeralCommon.Utils.Extensions;

public static class PlayerControllerBExtensions
{
    [UsedImplicitly]
    public static bool IsLocalPlayer(this PlayerControllerB playerControllerB)
    {
        return playerControllerB == GameNetworkManager.Instance.localPlayerController;
    }
}
