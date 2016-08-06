namespace OffLangParser
{
    using System.Collections.Generic;
    using System.Globalization;

    public class SynonymsParser : LanguageWordListParser<Synonym>
    {
        public SynonymsParser()
            : base(Prefixes.Synonyms)
        {
        }

        protected override Synonym BuildResult(CultureData language, IReadOnlyList<string> words)
        {
            return new Synonym(language, words);
        }
    }
}
