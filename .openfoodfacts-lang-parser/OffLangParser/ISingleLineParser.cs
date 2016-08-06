namespace OffLangParser
{
    public interface ISingleLineParser<TResult>
    {
        bool TryParse(string line, out TResult result);
    }
}
