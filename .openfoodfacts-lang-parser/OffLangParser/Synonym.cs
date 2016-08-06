namespace OffLangParser
{
    using System.Collections.Generic;
    using System.Globalization;

    public class Synonym : LanguageWordList
    {
        public Synonym(CultureData language, IReadOnlyList<string> words)
            : base(language, words)
        {
        }
    }
}
