namespace OffLangParser
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "WordList")]
    public class LanguageWordList : LanguageEntry
    {
        private readonly IReadOnlyList<string> words;

        public LanguageWordList(CultureData language, IReadOnlyList<string> words)
            : base(language)
        {
            if (words == null)
            {
                throw new ArgumentNullException(nameof(words));
            }

            this.words = words;
        }

        public IReadOnlyList<string> Words
        {
            get
            {
                return this.words;
            }
        }
    }
}
