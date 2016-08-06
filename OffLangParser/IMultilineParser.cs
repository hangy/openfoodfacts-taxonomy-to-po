namespace OffLangParser
{
    using System.Collections.Generic;

    public interface IMultilineParser<TResult>
    {
        bool TryParse(IReadOnlyList<string> lines, out TResult result);
    }
}
