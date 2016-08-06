namespace OffLangParser
{
    using System.Collections.Generic;
    using System.Globalization;

    public class WikipediaCategory : LinkedData
    {
        public WikipediaCategory(CultureData language, IReadOnlyList<string> words)
            : base(language, words)
        {
        }

        public override string Prefix
        {
            get
            {
                return Prefixes.WikipediaCategory;
            }
        }
    }
}
