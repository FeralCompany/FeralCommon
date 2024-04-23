using JetBrains.Annotations;
using LethalConfig.ConfigItems;
using LethalConfig.ConfigItems.Options;

namespace FeralCommon.Config;

[UsedImplicitly]
public class FloatConfig(string section, string key) : RangeConfig<FloatConfig, float>(section, key)
{
    private bool Slider { get; set; } = true;
    private float Step { get; set; } = 0.1f;

    [UsedImplicitly]
    public FloatConfig NoSlider()
    {
        Slider = false;
        return this;
    }

    [UsedImplicitly]
    public FloatConfig WithStep(float step)
    {
        Step = step;
        return this;
    }

    protected internal override BaseConfigItem CreateConfigItem()
    {
        if (Slider && IsRanged)
        {
            var options = new FloatStepSliderOptions { Min = Min, Max = Max, Step = Step };
            return new FloatSliderConfigItem(ValidatedEntry, FillBaseOptions(options));
        }
        else
        {
            var options = IsRanged ? new FloatInputFieldOptions { Min = Min, Max = Max } : new FloatInputFieldOptions();
            return new FloatInputFieldConfigItem(ValidatedEntry, FillBaseOptions(options));
        }
    }
}
