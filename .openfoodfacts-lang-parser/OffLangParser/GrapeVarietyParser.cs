namespace OffLangParser
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Wikidata")]
    public class GrapeVarietyParser : LanguageWordListParser<LinkedData>
    {
        public GrapeVarietyParser()
            : base(Prefixes.GrapeVariety)
        {
        }

        protected override LinkedData BuildResult(CultureData language, IReadOnlyList<string> words)
        {
            return new GrapeVariety(language, words);
        }
    }
}
