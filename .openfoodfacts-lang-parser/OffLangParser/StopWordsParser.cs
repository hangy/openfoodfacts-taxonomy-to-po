namespace OffLangParser
{
    using System.Collections.Generic;
    using System.Globalization;

    public class StopWordsParser : LanguageWordListParser<StopWords>
    {
        public StopWordsParser()
            : base(Prefixes.StopWords)
        {
        }

        protected override StopWords BuildResult(CultureData language, IReadOnlyList<string> words)
        {
            return new StopWords(language, words);
        }
    }
}
