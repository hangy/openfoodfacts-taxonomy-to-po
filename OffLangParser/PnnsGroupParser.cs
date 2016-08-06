namespace OffLangParser
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Pnns")]
    public class PnnsGroupParser : LanguageWordListParser<LinkedData>
    {
        private readonly int group;

        public PnnsGroupParser(int group)
            : base($"{Prefixes.PnnsGroup}_{group}")
        {
            PnnsGroupValidator.EnsureIsInRange(group);
            this.group = group;
        }

        protected override LinkedData BuildResult(CultureData language, IReadOnlyList<string> words)
        {
            return new PnnsGroup(language, words, this.group);
        }
    }
}
