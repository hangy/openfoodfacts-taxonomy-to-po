namespace OffLangParser
{
    using System;
    using System.Collections.Generic;

    public class LinkedDataParser : ISingleLineParser<LinkedData>
    {
        private readonly IReadOnlyList<PrefixOnlyParser<LinkedData>> parsers;

        public LinkedDataParser(IReadOnlyList<PrefixOnlyParser<LinkedData>> parsers)
        {
            if (parsers == null)
            {
                throw new ArgumentNullException(nameof(parsers));
            }

            this.parsers = parsers;
        }

        public bool TryParse(string line, out LinkedData result)
        {
            foreach (var parser in this.parsers)
            {
                if (parser.TryParse(line, out result))
                {
                    return true;
                }
            }

            result = null;
            return false;
        }
    }
}
