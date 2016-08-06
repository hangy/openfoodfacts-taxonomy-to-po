namespace OffLangParser.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Globalization;

    [TestClass]
    public class TranslationTests
    {
        [TestMethod]
        public void TestCanConstruct()
        {
            var translation = new Translation(new CultureData(CultureInfo.CurrentCulture), new List<string>());

            Assert.IsInstanceOfType(translation, typeof(LanguageWordList));
        }
    }
}
