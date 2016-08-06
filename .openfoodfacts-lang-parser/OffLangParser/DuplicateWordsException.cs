namespace OffLangParser
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DuplicateWordsException : Exception
    {
        public DuplicateWordsException()
        {
        }

        public DuplicateWordsException(string message)
            : base(message)
        {
        }

        internal DuplicateWordsException(IReadOnlyList<LinkedLangFileParser.WordCount> dupes)
            : this(BuildMessage(dupes))
        {
            if (dupes == null)
            {
                throw new ArgumentNullException(nameof(dupes));
            }

            this.Dupes = dupes;
        }

        public DuplicateWordsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        internal IReadOnlyList<LinkedLangFileParser.WordCount> Dupes { get; }

        private static string BuildMessage(IReadOnlyList<LinkedLangFileParser.WordCount> dupes)
        {
            var message = new StringBuilder(dupes.Count * 100);
            message.AppendLine("Duplicate words:");
            foreach (var dupe in dupes)
            {
                message.AppendLine(dupe.ToString());
            }

            return message.ToString();
        }
    }
}
