using System;
using System.Collections;
using GameNetcodeStuff;
using JetBrains.Annotations;
using UnityEngine;

namespace FeralCommon.Utils;

[UsedImplicitly]
public static class Player
{
    [UsedImplicitly]
    public static IEnumerator WhenLocalPlayerReady(Action<PlayerControllerB> action)
    {
        yield return new WaitUntil(() => GameNetworkManager.Instance && GameNetworkManager.Instance.localPlayerController);
        action.Invoke(GameNetworkManager.Instance.localPlayerController);
    }

    [UsedImplicitly]
    public static bool IsLocalPlayer(PlayerControllerB player)
    {
        return GameNetworkManager.Instance && GameNetworkManager.Instance.localPlayerController == player;
    }

    [UsedImplicitly]
    public static PlayerControllerB LocalPlayer()
    {
        return GameNetworkManager.Instance?.localPlayerController ?? throw new InvalidOperationException("Local player not ready!");
    }

    [UsedImplicitly]
    public static PlayerControllerB? LocalPlayerNullable()
    {
        return GameNetworkManager.Instance?.localPlayerController;
    }
}
