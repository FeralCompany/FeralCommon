using System.Diagnostics.CodeAnalysis;

namespace FeralCommon.Config;

[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public class StringConfig : Config<StringConfig, string>
{
    public int CharacterLimit { get; private set; }
    public int NumberOfLines { get; private set; } = 1;
    public bool TrimText { get; private set; }

    public StringConfig WithCharacterLimit(int characterLimit)
    {
        CharacterLimit = characterLimit;
        return this;
    }

    public StringConfig WithNumberOfLines(int numberOfLines)
    {
        NumberOfLines = numberOfLines;
        return this;
    }

    public StringConfig WithTrimText(bool trimText)
    {
        TrimText = trimText;
        return this;
    }
}
