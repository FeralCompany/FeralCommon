using System.Diagnostics.CodeAnalysis;
using BepInEx.Configuration;

namespace FeralCommon.Config;

[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public class FloatConfig : Config<FloatConfig, float>
{
    public float Min { get; private set; }
    public float Max { get; private set; }
    public float Step { get; private set; } = 0.1F;

    public FloatConfig WithRange(float min, float max)
    {
        Min = min;
        Max = max;
        return this;
    }

    public FloatConfig WithStep(float step)
    {
        Step = step;
        return this;
    }

    protected override AcceptableValueBase CreateAcceptableValue()
    {
        return new AcceptableValueRange<float>(Min, Max);
    }
}
