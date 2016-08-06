namespace OffLangParser
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Wikidata")]
    public class WikidataCategory : LinkedData
    {
        public WikidataCategory(CultureData language, IReadOnlyList<string> words)
            : base(language, words)
        {
        }

        public override string Prefix
        {
            get
            {
                return Prefixes.WikidataCategory;
            }
        }
    }
}
