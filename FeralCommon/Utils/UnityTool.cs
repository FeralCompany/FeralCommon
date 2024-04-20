using JetBrains.Annotations;
using UnityEngine;

namespace FeralCommon.Utils;

public static class UnityTool
{
    [UsedImplicitly]
    public static GameObject CreateRootGameObject(string? name = null)
    {
        var obj = name == null ? new GameObject() : new GameObject(name);
        Object.DontDestroyOnLoad(obj);
        obj.hideFlags = HideFlags.HideAndDontSave;
        return obj;
    }
}
