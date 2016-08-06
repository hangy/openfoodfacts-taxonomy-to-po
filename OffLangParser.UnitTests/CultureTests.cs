namespace OffLangParser.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Globalization;

    [TestClass]
    public class CultureTests
    {
        [TestMethod]
        public void TestDeGetsCorrectCulture()
        {
            var expected = "de";

            var culture = Culture.FromIsoName(expected);
            var actual = culture.Name;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestZzGetsDummyCulture()
        {
            var expectedName = "zz";

            var culture = Culture.FromIsoName(expectedName);

            Assert.IsNotNull(culture);
            Assert.AreEqual(expectedName, culture.Name);
            Assert.AreEqual(4096, culture.CompareInfo.LCID);
        }
    }
}
