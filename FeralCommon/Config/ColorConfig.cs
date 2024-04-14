using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace FeralCommon.Config;

[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public class ColorConfig : Config<ColorConfig, string>
{
    public Color ToColor()
    {
        return ColorUtility.TryParseHtmlString(this, out var color) ? color : Color.white;
    }

    public static implicit operator Color(ColorConfig config)
    {
        return config.ToColor();
    }
}
