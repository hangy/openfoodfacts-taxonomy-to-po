namespace OffLangParser
{
    using System.Collections.Generic;

    public class InstanceOf : LinkedData
    {
        public InstanceOf(CultureData language, IReadOnlyList<string> words)
            : base(language, words)
        {
        }

        public override string Prefix
        {
            get
            {
                return Prefixes.InstanceOf;
            }
        }
    }
}
