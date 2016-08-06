namespace OffLangParser
{
    using System.Collections.Generic;
    using System.Globalization;

    public class Translation : LanguageWordList
    {
        public Translation(CultureData language, IReadOnlyList<string> words)
            : base(language, words)
        {
        }
    }
}
