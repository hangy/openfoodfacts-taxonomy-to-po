namespace OffLangParser.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Globalization;

    [TestClass]
    public class SynonymTests
    {
        [TestMethod]
        public void TestCanConstruct()
        {
            var synonym = new Synonym(new CultureData(CultureInfo.CurrentCulture), new List<string>());

            Assert.IsInstanceOfType(synonym, typeof(LanguageWordList));
        }
    }
}
