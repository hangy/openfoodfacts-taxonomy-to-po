namespace OffLangParser
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class LangFileParser
    {
        private readonly ISingleLineParser<StopWords> stopWordsParser;

        private readonly ISingleLineParser<Synonym> synonymsParser;

        private readonly IMultilineParser<TranslationSet> translationSetParser;

        public LangFileParser(
            ISingleLineParser<StopWords> stopWordsParser,
            ISingleLineParser<Synonym> synonymsParser,
            IMultilineParser<TranslationSet> translationSetParser)
        {
            if (stopWordsParser == null)
            {
                throw new ArgumentNullException(nameof(stopWordsParser));
            }

            if (synonymsParser == null)
            {
                throw new ArgumentNullException(nameof(synonymsParser));
            }

            if (translationSetParser == null)
            {
                throw new ArgumentNullException(nameof(translationSetParser));
            }

            this.stopWordsParser = stopWordsParser;
            this.synonymsParser = synonymsParser;
            this.translationSetParser = translationSetParser;
        }

        public LangFile Parse(Stream stream, Encoding encoding)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (encoding == null)
            {
                throw new ArgumentNullException(nameof(encoding));
            }

            var stopwordList = new List<StopWords>();
            var synonymList = new List<Synonym>();
            var translationSetList = new List<TranslationSet>();

            using (var reader = new StreamReader(stream, encoding, true, 1, true))
            {
                var lines = new List<string>();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    StopWords stopwords;
                    if (this.stopWordsParser.TryParse(line, out stopwords))
                    {
                        stopwordList.Add(stopwords);
                        continue;
                    }

                    Synonym synonym;
                    if (this.synonymsParser.TryParse(line, out synonym))
                    {
                        synonymList.Add(synonym);
                        continue;
                    }

                    if (string.IsNullOrWhiteSpace(line) && lines.Count > 0)
                    {
                        TranslationSet translationSet;
                        if (this.translationSetParser.TryParse(lines, out translationSet))
                        {
                            translationSetList.Add(translationSet);
                            lines.Clear();
                            continue;
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(line))
                    {
                        lines.Add(line);
                    }
                }

                TranslationSet lastTanslationSet;
                if (this.translationSetParser.TryParse(lines, out lastTanslationSet))
                {
                    translationSetList.Add(lastTanslationSet);
                    lines.Clear();
                }
            }

            return new LangFile(stopwordList, synonymList, translationSetList);
        }
    }
}
