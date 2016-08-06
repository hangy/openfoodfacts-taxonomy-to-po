namespace OffLangParser
{
    using System.Collections.Generic;

    public class WikipediaCategoryParser : LanguageWordListParser<LinkedData>
    {
        public WikipediaCategoryParser()
            : base(Prefixes.WikipediaCategory)
        {
        }

        protected override LinkedData BuildResult(CultureData language, IReadOnlyList<string> words)
        {
            return new WikipediaCategory(language, words);
        }
    }
}
