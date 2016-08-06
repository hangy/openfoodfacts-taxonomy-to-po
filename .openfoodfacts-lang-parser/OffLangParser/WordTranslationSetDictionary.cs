namespace OffLangParser
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix", Justification = "It poses as a Dictionary, not a Collection.")]
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "It poses as a Dictionary, not a Collection.")]
    public class WordTranslationSetDictionary : IReadOnlyDictionary<Word, TranslationSet>
    {
        private readonly int sourceCount;

        private readonly ILookup<CultureData, KeyValuePair<Word, TranslationSet>> lookup;

        public WordTranslationSetDictionary(IReadOnlyDictionary<Word, TranslationSet> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            this.sourceCount = source.Count;
            this.lookup = source.ToLookup(kvp => kvp.Key.Language);
        }

        public TranslationSet this[Word key]
        {
            get
            {
                if (key == null)
                {
                    throw new ArgumentNullException(nameof(key));
                }

                var bucket = this.lookup[key.Language];
                var sets = bucket.Where(kvp => kvp.Key.Equals(key)).ToList();
                var values = sets.Select(kvp => kvp.Value).ToList();
                return values.SingleOrDefault();
            }
        }

        public int Count
        {
            get
            {
                return this.sourceCount;
            }
        }

        public IEnumerable<Word> Keys
        {
            get
            {
                return this.lookup.SelectMany(k => k).Select(k => k.Key);
            }
        }

        public IEnumerable<TranslationSet> Values
        {
            get
            {
                return this.lookup.SelectMany(k => k).Select(k => k.Value);
            }
        }

        public bool ContainsKey(Word key)
        {
            return this[key] != null;
        }

        public IEnumerator<KeyValuePair<Word, TranslationSet>> GetEnumerator()
        {
            return this.lookup.SelectMany(g => g).Select(v => v).GetEnumerator();
        }

        public bool TryGetValue(Word key, out TranslationSet value)
        {
            value = this[key];
            return value != null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
