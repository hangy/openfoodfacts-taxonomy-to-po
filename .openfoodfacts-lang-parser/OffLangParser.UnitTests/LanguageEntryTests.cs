namespace OffLangParser.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Globalization;

    [TestClass]
    public class LanguageEntryTests
    {
        [TestMethod]
        public void TestThatCultureIsSavedAndReturned()
        {
            var culture = new CultureData(CultureInfo.CurrentCulture);

            var entry = new LanguageEntry(culture);

            Assert.AreEqual(culture, entry.Language);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestThatConstructorThrowsOnMissingCulture()
        {
            new LanguageEntry(null);
        }
    }
}
