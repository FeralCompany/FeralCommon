using System.Collections.Generic;
using BepInEx.Configuration;
using JetBrains.Annotations;
using LethalConfig.ConfigItems;
using LethalConfig.ConfigItems.Options;

namespace FeralCommon.Config;

[UsedImplicitly]
public class StringConfig(string section, string key) : Config<StringConfig, string>(section, key)
{
    private List<string> AcceptableValues { get; } = [];
    private bool HasAcceptableValues => AcceptableValues.Count > 0;

    private int CharacterLimit { get; set; }
    private int NumberOfLines { get; set; } = 1;
    private bool TrimText { get; set; }

    [UsedImplicitly]
    public StringConfig AddAcceptableValue(string value)
    {
        AcceptableValues.Add(value);
        return this;
    }

    [UsedImplicitly]
    public StringConfig AddAcceptableValues(params string[] values)
    {
        AcceptableValues.AddRange(values);
        return this;
    }

    [UsedImplicitly]
    public StringConfig AddAcceptableValues(IEnumerable<string> values)
    {
        AcceptableValues.AddRange(values);
        return this;
    }

    [UsedImplicitly]
    public StringConfig WithCharacterLimit(int limit)
    {
        CharacterLimit = limit;
        return this;
    }

    [UsedImplicitly]
    public StringConfig WithNumberOfLines(int lines)
    {
        NumberOfLines = lines;
        return this;
    }

    [UsedImplicitly]
    public StringConfig SetTrimText()
    {
        TrimText = true;
        return this;
    }

    protected override AcceptableValueBase? CreateAcceptableValue()
    {
        return HasAcceptableValues ? new AcceptableValueList<string>(AcceptableValues.ToArray()) : null;
    }

    protected internal override BaseConfigItem CreateConfigItem()
    {
        if (HasAcceptableValues)
        {
            var options = new TextDropDownOptions { Values = AcceptableValues.ToArray() };
            return new TextDropDownConfigItem(ValidatedEntry, FillBaseOptions(options));
        }
        else
        {
            var options = new TextInputFieldOptions { CharacterLimit = CharacterLimit, NumberOfLines = NumberOfLines, TrimText = TrimText };
            return new TextInputFieldConfigItem(ValidatedEntry, FillBaseOptions(options));
        }
    }
}
