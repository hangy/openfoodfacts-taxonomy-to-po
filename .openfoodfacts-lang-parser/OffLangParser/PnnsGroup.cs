namespace OffLangParser
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Pnns")]
    public class PnnsGroup : LinkedData
    {
        private readonly int group;

        public PnnsGroup(CultureData language, IReadOnlyList<string> words, int group)
            : base(language, words)
        {
            PnnsGroupValidator.EnsureIsInRange(group);
            this.group = group;
        }

        public int Group
        {
            get
            {
                return this.group;
            }
        }

        public override string Prefix
        {
            get
            {
                return $"{Prefixes.PnnsGroup}_{this.group}";
            }
        }
    }
}
