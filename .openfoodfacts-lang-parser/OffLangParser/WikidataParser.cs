namespace OffLangParser
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Wikidata")]
    public class WikidataParser : LanguageWordListParser<LinkedData>
    {
        public WikidataParser()
            : base(Prefixes.Wikidata)
        {
        }

        protected override LinkedData BuildResult(CultureData language, IReadOnlyList<string> words)
        {
            return new Wikidata(language, words);
        }
    }
}
