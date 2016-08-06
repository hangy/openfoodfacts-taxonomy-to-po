namespace OffLangParser
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Wikidata")]
    public class WikidataCategoryParser : LanguageWordListParser<LinkedData>
    {
        public WikidataCategoryParser()
            : base(Prefixes.WikidataCategory)
        {
        }

        protected override LinkedData BuildResult(CultureData language, IReadOnlyList<string> words)
        {
            return new WikidataCategory(language, words);
        }
    }
}
