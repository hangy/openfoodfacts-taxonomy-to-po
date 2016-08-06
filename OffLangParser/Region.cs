namespace OffLangParser
{
    using System.Collections.Generic;

    public class Region : LinkedData
    {
        public Region(CultureData language, IReadOnlyList<string> words)
            : base(language, words)
        {
        }

        public override string Prefix
        {
            get
            {
                return Prefixes.Region;
            }
        }
    }
}
