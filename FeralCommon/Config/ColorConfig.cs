using UnityEngine;

namespace FeralCommon.Config;

public class ColorConfig : StringConfig
{
    public ColorConfig()
    {
        WithCharacterLimit(7);
        WithNumberOfLines(1);
        WithTrimText(true);
    }

    public Color ToColor()
    {
        return ColorUtility.TryParseHtmlString(this, out var color) ? color : Color.white;
    }
}
