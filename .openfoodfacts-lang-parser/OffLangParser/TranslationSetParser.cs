namespace OffLangParser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TranslationSetParser : IMultilineParser<TranslationSet>
    {
        private static readonly IReadOnlyList<TranslationSet> emptyTranslationSetList = new List<TranslationSet>(0);

        private static readonly IReadOnlyList<LinkedData> emptyLinkedDataList = new List<LinkedData>(0);

        private readonly ISingleLineParser<Translation> translationParser;

        private readonly ISingleLineParser<LinkedData> linkedDataParser;

        public TranslationSetParser(ISingleLineParser<Translation> translationParser, ISingleLineParser<LinkedData> linkedDataParser)
        {
            if (translationParser == null)
            {
                throw new ArgumentNullException(nameof(translationParser));
            }

            if (linkedDataParser == null)
            {
                throw new ArgumentNullException(nameof(linkedDataParser));
            }

            this.translationParser = translationParser;
            this.linkedDataParser = linkedDataParser;
        }

        public bool TryParse(IReadOnlyList<string> lines, out TranslationSet result)
        {
            if (lines == null)
            {
                throw new ArgumentNullException(nameof(lines));
            }

            var parents = lines.Where(l => l.StartsWith(Constants.ParentIndicator, StringComparison.OrdinalIgnoreCase));
            var values = lines.Where(l => !l.StartsWith(Constants.ParentIndicator, StringComparison.OrdinalIgnoreCase));

            var parentSets = new List<TranslationSet>();
            foreach (var line in parents)
            {
                var trimmedLine = line.Substring(Constants.ParentIndicator.Length, line.Length - Constants.ParentIndicator.Length).Trim();

                var parentSetTranslations = new List<Translation>();
                Translation translation;
                if (this.translationParser.TryParse(trimmedLine, out translation))
                {
                    parentSetTranslations.Add(translation);
                }

                parentSets.Add(new TranslationSet(emptyTranslationSetList, parentSetTranslations, emptyLinkedDataList));
            }

            var translations = new List<Translation>(lines.Count);
            var linkedDatas = new List<LinkedData>(lines.Count);
            foreach (var line in values)
            {
                LinkedData linkedData;
                Translation translation;
                if (this.linkedDataParser.TryParse(line, out linkedData))
                {
                    linkedDatas.Add(linkedData);
                }
                else if (this.translationParser.TryParse(line, out translation))
                {
                    translations.Add(translation);
                }                
            }

            result = new TranslationSet(parentSets, translations, linkedDatas);
            return true;
        }
    }
}
