using System;
using BepInEx.Configuration;
using JetBrains.Annotations;

namespace FeralCommon.Config;

public abstract class RangeConfig<TDerived, TType>(string section, string key)
    : Config<TDerived, TType>(section, key) where TDerived : RangeConfig<TDerived, TType>
    where TType : struct, IComparable, IComparable<TType>, IConvertible, IEquatable<TType>
{
    protected TType Min { get; private set; }
    protected TType Max { get; private set; }

    [UsedImplicitly]
    public TDerived WithMin(TType min)
    {
        Min = min;
        return (TDerived)this;
    }

    [UsedImplicitly]
    public TDerived WithMax(TType max)
    {
        Max = max;
        return (TDerived)this;
    }

    protected override AcceptableValueBase CreateAcceptableValue()
    {
        return new AcceptableValueRange<TType>(Min, Max);
    }
}
