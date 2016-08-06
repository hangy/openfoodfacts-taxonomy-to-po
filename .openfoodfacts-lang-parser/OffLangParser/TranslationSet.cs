namespace OffLangParser
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    public class TranslationSet
    {
        private readonly IReadOnlyList<TranslationSet> parents;

        private readonly IReadOnlyList<Translation> translations;

        private readonly IReadOnlyList<LinkedData> linkedData;

        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "wikidata")]
        public TranslationSet(IReadOnlyList<TranslationSet> parents, IReadOnlyList<Translation> translations, IReadOnlyList<LinkedData> linkedData)
        {
            if (parents == null)
            {
                throw new ArgumentNullException(nameof(parents));
            }

            if (translations == null)
            {
                throw new ArgumentNullException(nameof(translations));
            }

            if (linkedData == null)
            {
                throw new ArgumentNullException(nameof(linkedData));
            }

            this.parents = parents;
            this.translations = translations;
            this.linkedData = linkedData;
        }

        public IReadOnlyList<TranslationSet> Parents
        {
            get
            {
                return this.parents;
            }
        }

        public IReadOnlyList<Translation> Translations
        {
            get
            {
                return this.translations;
            }
        }

        public IReadOnlyList<LinkedData> LinkedData
        {
            get
            {
                return this.linkedData;
            }
        }
    }
}
