using System.Diagnostics.CodeAnalysis;
using BepInEx.Configuration;

namespace FeralCommon.Config;

[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public class IntConfig : Config<IntConfig, int>
{
    public int Min { get; private set; }
    public int Max { get; private set; }

    public IntConfig WithRange(int min, int max)
    {
        Min = min;
        Max = max;
        return this;
    }

    protected override AcceptableValueBase CreateAcceptableValue()
    {
        return new AcceptableValueRange<int>(Min, Max);
    }
}
