namespace OffLangParser.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Globalization;

    [TestClass]
    public class StopWordsTests
    {
        [TestMethod]
        public void TestCanConstruct()
        {
            var stopWords = new StopWords(new CultureData(CultureInfo.CurrentCulture), new List<string>());

            Assert.IsInstanceOfType(stopWords, typeof(LanguageWordList));
        }
    }
}
