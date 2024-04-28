using JetBrains.Annotations;
using UnityEngine;

namespace FeralCommon.Utils.Extensions;

public static class GameObjectExtensions
{
    [UsedImplicitly]
    public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
    {
        var component = gameObject.GetComponent<T>();
        return component ? component : gameObject.AddComponent<T>();
    }
}
