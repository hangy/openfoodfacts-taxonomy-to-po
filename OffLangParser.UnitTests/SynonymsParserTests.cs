namespace OffLangParser.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SynonymsParserTests
    {
        [TestMethod]
        public void TestThatTryParseReturnsFalseForNonMatchingPrefix()
        {
            var parser = new SynonymsParser();

            Synonym synonym;
            var result = parser.TryParse(null, out synonym);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestThatTryParseReturnsFalseForMatchingPrefixButMissingLanguage()
        {
            const string line = "synonyms:test,this,for,real";
            var parser = new SynonymsParser();

            Synonym synonym;
            var result = parser.TryParse(line, out synonym);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestThatTryParseReturnsTrueForMatchingPrefix()
        {
            const string line = "synonyms:en:test,this,for,real";
            var parser = new SynonymsParser();

            Synonym synonym;
            var result = parser.TryParse(line, out synonym);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestThatTryParseReturnsMultipleWordsForMatchingPrefix()
        {
            const string line = "synonyms:en:test,this,for,real";
            var parser = new SynonymsParser();

            Synonym result;
            var parsed = parser.TryParse(line, out result);

            Assert.AreEqual("en", result.Language.Name);
            Assert.AreEqual(4, result.Words.Count);
            Assert.AreEqual("test", result.Words[0]);
            Assert.AreEqual("this", result.Words[1]);
            Assert.AreEqual("for", result.Words[2]);
            Assert.AreEqual("real", result.Words[3]);
        }
    }
}
