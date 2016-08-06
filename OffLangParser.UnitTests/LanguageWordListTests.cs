namespace OffLangParser.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    [TestClass]
    public class LanguageWordListTests
    {
        [TestMethod]
        public void TestThatWordListIsStoredAndReturned()
        {
            var words = new List<string>(0);

            var list = new LanguageWordList(new CultureData(CultureInfo.CurrentCulture), words);

            Assert.AreEqual(words, list.Words);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestThatConstructorThrowsOnMissingList()
        {
            new LanguageWordList(new CultureData(CultureInfo.CurrentCulture), null);
        }
    }
}
