namespace OffTaxonomyToPo
{
    using OffLangParser;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PoWriter : IDisposable
    {
        private readonly IDictionary<string, TextWriter> writers = new Dictionary<string, TextWriter>();

        public async Task WriteAsync(LangFile langFile)
        {
            if (langFile == null)
            {
                throw new ArgumentNullException(nameof(langFile));
            }

            foreach (var ts in langFile.TranslationSets)
            {
                await this.WriteAsync(ts);
            }
        }

        private async Task WriteAsync(TranslationSet translationSet)
        {
            var msgId = this.GetMessageId(translationSet);
            if (msgId == null)
            {
                return;
            }

            foreach (var t in translationSet.Translations)
            {
                await this.WriteAsync(msgId, t);
            }
        }

        private async Task WriteAsync(Translation msgId, Translation translation)
        {
            var writer = this.GetWriter(translation);
            await writer.WriteAsync("msgid \"");
            await writer.WriteAsync(msgId.Words.First());
            await writer.WriteLineAsync("\"");

            await writer.WriteAsync("msgstr \"");
            await writer.WriteAsync(string.Join(", ", translation.Words));
            await writer.WriteLineAsync("\"");

            await writer.WriteLineAsync();
        }

        private TextWriter GetWriter(Translation translation)
        {
            return this.GetWriter(translation.Language);
        }

        private TextWriter GetWriter(CultureData language)
        {
            return this.GetWriter(language.Name);
        }

        private TextWriter GetWriter(string code)
        {
            TextWriter result;
            if (!this.writers.TryGetValue(code, out result))
            {
                result = new StreamWriter(new FileStream($"{code}.po", FileMode.CreateNew, FileAccess.ReadWrite, FileShare.Read), Encoding.UTF8);
                this.writers.Add(code, result);
            }

            return result;
        }

        private Translation GetMessageId(TranslationSet translationSet)
        {
            var en = translationSet.Translations.FirstOrDefault(t => "en".Equals(t.Language.Name) && t.Words.Any());
            if (en != null)
            {
                return en;
            }

            return translationSet.Translations.FirstOrDefault(t => t.Words.Any());
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (var writer in writers.Values)
                {
                    writer.Dispose();
                }
            }
        }
    }
}
