namespace OffLangParser
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Wikidata")]
    public class InstanceOfParser : LanguageWordListParser<LinkedData>
    {
        public InstanceOfParser()
            : base(Prefixes.InstanceOf)
        {
        }

        protected override LinkedData BuildResult(CultureData language, IReadOnlyList<string> words)
        {
            return new InstanceOf(language, words);
        }
    }
}
