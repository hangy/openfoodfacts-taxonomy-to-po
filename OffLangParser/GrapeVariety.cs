namespace OffLangParser
{
    using System.Collections.Generic;

    public class GrapeVariety : LinkedData
    {
        public GrapeVariety(CultureData language, IReadOnlyList<string> words)
            : base(language, words)
        {
        }

        public override string Prefix
        {
            get
            {
                return Prefixes.GrapeVariety;
            }
        }
    }
}
