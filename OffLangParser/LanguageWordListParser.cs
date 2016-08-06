namespace OffLangParser
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "WordList")]
    public abstract class LanguageWordListParser<TResult> : PrefixOnlyParser<TResult>
    {
        protected LanguageWordListParser(string prefix)
            : base(prefix)
        {
        }

        protected override bool TryParseWithoutPrefix(string lineWithoutPrefix, out TResult result)
        {
            if (lineWithoutPrefix == null)
            {
                throw new ArgumentNullException(nameof(lineWithoutPrefix));
            }

            result = default(TResult);

            var split = lineWithoutPrefix.Split(Constants.LanguageSeparator);
            if (split.Length != 2)
            {
                return false;
            }

            var language = Culture.FromIsoName(split[0].Trim());
            if (language == null)
            {
                return false;
            }

            var words = split[1].Trim().Split(Constants.TermSeparator).Select(w => w.Trim()).Where(w => !string.IsNullOrWhiteSpace(w)).ToList();
            result = this.BuildResult(language, words);
            return true;
        }

        protected abstract TResult BuildResult(CultureData language, IReadOnlyList<string> words);
    }
}
