using FeralCommon.Game;
using JetBrains.Annotations;

namespace FeralCommon.Utils.Extensions;

public static class GrabbableObjectExtensions
{
    [UsedImplicitly]
    public static GameItem? ToGameItem(this GrabbableObject obj)
    {
        return GameItems.FromGrabbable(obj);
    }

    [UsedImplicitly]
    public static bool IsConductive(this GrabbableObject obj)
    {
        return obj.itemProperties.isConductiveMetal;
    }
}
