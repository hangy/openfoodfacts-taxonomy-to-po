namespace OffLangParser
{
    using System.Collections.Generic;
    using System.Globalization;

    public class TranslationParser : LanguageWordListParser<Translation>
    {
        public TranslationParser()
            : base(null)
        {
        }

        protected override Translation BuildResult(CultureData language, IReadOnlyList<string> words)
        {
            return new Translation(language, words);
        }
    }
}
