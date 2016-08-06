namespace OffLangParser
{
    using System.Collections.Generic;
    using System.Globalization;

    public abstract class LinkedData : LanguageWordList
    {
        protected LinkedData(CultureData language, IReadOnlyList<string> words)
            : base(language, words)
        {
        }

        public abstract string Prefix { get; }
    }
}