namespace OffLangParser
{
    using System.Collections.Generic;

    public class Label : LinkedData
    {
        public Label(CultureData language, IReadOnlyList<string> words)
            : base(language, words)
        {
        }

        public override string Prefix
        {
            get
            {
                return Prefixes.Country;
            }
        }
    }
}
