using JetBrains.Annotations;
using LethalConfig.ConfigItems;
using LethalConfig.ConfigItems.Options;

namespace FeralCommon.Config;

[UsedImplicitly]
public class IntConfig(string section, string key) : RangeConfig<IntConfig, int>(section, key)
{
    private bool Slider { get; set; } = true;

    [UsedImplicitly]
    public IntConfig NoSlider()
    {
        Slider = false;
        return this;
    }

    protected internal override BaseConfigItem CreateConfigItem()
    {
        if (Slider && IsRanged)
        {
            var options = new IntSliderOptions { Min = Min, Max = Max };
            return new IntSliderConfigItem(ValidatedEntry, FillBaseOptions(options));
        }
        else
        {
            var options = IsRanged ? new IntInputFieldOptions { Min = Min, Max = Max } : new IntInputFieldOptions();
            return new IntInputFieldConfigItem(ValidatedEntry, FillBaseOptions(options));
        }
    }
}
