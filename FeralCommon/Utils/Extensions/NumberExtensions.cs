using JetBrains.Annotations;

namespace FeralCommon.Utils.Extensions;

public static class NumberExtensions
{
    [UsedImplicitly]
    public static bool IsPowerOfTwo(this int num)
    {
        return num != 0 && (num & (num - 1)) == 0;
    }
}
