namespace OffLangParser
{
    using System;
    using System.Globalization;

    public class Word : LanguageEntry
    {
        private readonly string name;

        public Word(string name, CultureData language)
            : base(language)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            this.name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public override bool Equals(object obj)
        {
            var word = obj as Word;
            if (word == null)
            {
                return false;
            }

            if (!word.Language.Equals(this.Language))
            {
                return false;
            }

            return this.Language.CompareInfo.Compare(this.Name, word.Name, CompareOptions.IgnoreCase) == 0;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(this.Language, this.Name).GetHashCode();
        }
    }
}
