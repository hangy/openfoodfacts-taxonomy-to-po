namespace OffLangParser
{
    using System;
    using System.Globalization;

    public class LanguageEntry
    {
        private readonly CultureData language;

        public LanguageEntry(CultureData language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(nameof(language));
            }

            this.language = language;
        }

        public CultureData Language
        {
            get
            {
                return this.language;
            }
        }
    }
}
