namespace OffLangParser
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    public class LabelParser : LanguageWordListParser<LinkedData>
    {
        public LabelParser()
            : base(Prefixes.Label)
        {
        }

        protected override LinkedData BuildResult(CultureData language, IReadOnlyList<string> words)
        {
            return new Label(language, words);
        }
    }
}
