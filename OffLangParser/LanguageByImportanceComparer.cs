namespace OffLangParser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    public class LanguageByImportanceComparer : IComparer<CultureData>
    {
        private readonly IReadOnlyList<TranslationSet> translationSets;

        private readonly Lazy<List<CultureData>> languages;

        public LanguageByImportanceComparer(IReadOnlyList<TranslationSet> translationSets)
        {
            if (translationSets == null)
            {
                throw new ArgumentNullException(nameof(translationSets));
            }

            this.translationSets = translationSets;
            this.languages = new Lazy<List<CultureData>>(this.BuildLanguageList, LazyThreadSafetyMode.PublicationOnly);
        }

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Justification = "Should be validated just fine.")]
        public int Compare(CultureData x, CultureData y)
        {
            if (x == null && y == null)
            {
                return 0;
            }

            if (x != null && y == null)
            {
                return 1;
            }

            if (x == null && y != null)
            {
                return -1;
            }

            if (x.Equals(y))
            {
                return 0;
            }

            var languageList = this.languages.Value;
            var rankY = languageList.IndexOf(y);
            if (rankY < 0)
            {
                return -1;
            }

            var rankX = languageList.IndexOf(x);
            if (rankX < 0)
            {
                return 1;
            }

            Debug.Assert(rankX != rankY);
            return rankX > rankY ? -1 : 1;
        }

        private List<CultureData> BuildLanguageList()
        {
            var languages = new Dictionary<CultureData, int>(this.translationSets.Count);
            
            foreach (var translationSet in this.translationSets)
            {
                foreach (var translation in translationSet.Translations)
                {
                    if (languages.ContainsKey(translation.Language))
                    {
                        ++languages[translation.Language];
                    }
                    else
                    {
                        languages.Add(translation.Language, 1);
                    }                    
                }
            }

            var result = (from kvp in languages
                          orderby kvp.Value descending
                          select kvp.Key).ToList();
            var english = result.SingleOrDefault(l => l.Name == "en");
            if (english != null && result.Remove(english))
            {
                result.Insert(0, english);
            }

            return result;
        }
    }
}