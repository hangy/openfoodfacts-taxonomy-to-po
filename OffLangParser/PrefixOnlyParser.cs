namespace OffLangParser
{
    using System;

    public abstract class PrefixOnlyParser<TResult> : ISingleLineParser<TResult>
    {
        private readonly string prefix;

        protected PrefixOnlyParser(string prefix)
        {
            this.prefix = string.IsNullOrWhiteSpace(prefix) ? string.Empty : string.Concat(prefix, Constants.PrefixSeparator);
        }

        public bool TryParse(string line, out TResult result)
        {
            result = default(TResult);
            if (string.IsNullOrWhiteSpace(line))
            {
                return false;
            }

            line = line.Trim();
            if (!line.StartsWith(this.prefix, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            var lineWithoutPrefix = line.Substring(this.prefix.Length, line.Length - this.prefix.Length).Trim();
            return this.TryParseWithoutPrefix(lineWithoutPrefix, out result);
        }

        protected abstract bool TryParseWithoutPrefix(string lineWithoutPrefix, out TResult result);
    }
}
