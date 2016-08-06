namespace OffLangParser
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class LangFile
    {
        private readonly IReadOnlyList<StopWords> stopWords;

        private readonly IReadOnlyList<Synonym> synonyms;

        private readonly IReadOnlyList<TranslationSet> translationSets;

        public LangFile(IReadOnlyList<StopWords> stopWords, IReadOnlyList<Synonym> synonyms, IReadOnlyList<TranslationSet> translationSets)
        {
            if (stopWords == null)
            {
                throw new ArgumentNullException(nameof(stopWords));
            }

            if (synonyms == null)
            {
                throw new ArgumentNullException(nameof(synonyms));
            }

            if (translationSets == null)
            {
                throw new ArgumentNullException(nameof(translationSets));
            }

            this.stopWords = stopWords;
            this.synonyms = synonyms;
            this.translationSets = translationSets;
        }

        public IReadOnlyList<StopWords> StopWords
        {
            get
            {
                return this.stopWords;
            }
        }

        public IReadOnlyList<Synonym> Synonyms
        {
            get
            {
                return this.synonyms;
            }
        }

        public IReadOnlyList<TranslationSet> TranslationSets
        {
            get
            {
                return this.translationSets;
            }
        }

        public async Task WriteToAsync(TextWriter writer)
        {
            // TODO: Move to it's own file?
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            await WriteToAsync(writer, this.StopWords);
            await WriteToAsync(writer, this.Synonyms);
            await WriteToAsync(writer, this.TranslationSets);
        }

        private static async Task WriteToAsync(TextWriter writer, IReadOnlyList<StopWords> stopWords)
        {
            await WriteToAsync(writer, Prefixes.StopWords, stopWords);
            await writer.WriteLineAsync();
        }

        private static async Task WriteToAsync(TextWriter writer, IReadOnlyList<Synonym> synonyms)
        {
            await WriteToAsync(writer, Prefixes.Synonyms, synonyms);
            await writer.WriteLineAsync();
        }

        private static async Task WriteToAsync(TextWriter writer, string prefix, IReadOnlyList<LanguageWordList> wordLists)
        {
            foreach (var wordList in wordLists)
            {
                await WriteToAsync(writer, prefix, wordList);
            }
        }

        private static async Task WriteToAsync(TextWriter writer, string prefix, LanguageWordList wordList)
        {
            if (wordList.Words.Count == 0)
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(prefix))
            {
                await writer.WriteAsync(prefix);
                await writer.WriteAsync(Constants.PrefixSeparator);
            }

            await writer.WriteAsync(wordList.Language.Name);
            await writer.WriteAsync(Constants.LanguageSeparator);
            await writer.WriteLineAsync(string.Join(Constants.TermSeparator + " ", wordList.Words));
        }

        private static async Task WriteToAsync(TextWriter writer, IReadOnlyList<TranslationSet> translationSets)
        {
            var languageComparer = new LanguageByImportanceComparer(translationSets);

            foreach (var translationSet in translationSets)
            {
                await WriteToAsync(writer, translationSet, languageComparer);
            }
        }

        private static async Task WriteToAsync(TextWriter writer, TranslationSet translationSet, IComparer<CultureData> languageComparer)
        {
            if (translationSet.Translations.Count == 0 && translationSet.LinkedData.Count == 0)
            {
                return;
            }

            foreach (var parent in translationSet.Parents)
            {
                await WriteParentAsync(writer, parent, languageComparer);
            }

            var english = Culture.FromIsoName("en");
            foreach (var translation in translationSet.Translations.Where(t => t.Language.Equals(english))) // "en" first
            {
                await WriteTranslationAsync(writer, translation);
            }

            foreach (var translation in translationSet.Translations.Where(t => !t.Language.Equals(english)))
            {
                await WriteTranslationAsync(writer, translation);
            }

            foreach (var linkedData in translationSet.LinkedData)
            {
                await WriteTranslationAsync(writer, linkedData);
            }

            await writer.WriteLineAsync();
        }

        private static async Task WriteParentAsync(TextWriter writer, TranslationSet parent, IComparer<CultureData> languageComparer)
        {
            var mostImportantTranslation = parent.Translations.Where(t => t.Words.Count > 0).OrderByDescending(t => t.Language, languageComparer).FirstOrDefault();
            if (mostImportantTranslation == null)
            {
                return;
            }

            await writer.WriteAsync(Constants.ParentIndicator);
            await writer.WriteAsync(mostImportantTranslation.Language.Name);
            await writer.WriteAsync(Constants.LanguageSeparator);
            await writer.WriteLineAsync(string.Join(Constants.TermSeparator + " ", mostImportantTranslation.Words.First()));
        }

        private static async Task WriteTranslationAsync(TextWriter writer, Translation translation)
        {
            await WriteToAsync(writer, string.Empty, translation);
        }

        private static async Task WriteTranslationAsync(TextWriter writer, LinkedData linkedData)
        {
            await WriteToAsync(writer, linkedData.Prefix, linkedData);
        }
    }
}
