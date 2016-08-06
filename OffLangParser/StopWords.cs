namespace OffLangParser
{
    using System.Collections.Generic;
    using System.Globalization;

    public class StopWords : LanguageWordList
    {
        public StopWords(CultureData language, IReadOnlyList<string> words)
            : base(language, words)
        {
        }
    }
}
