using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace OffLangParser.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class PrefixOnlyParserTests
    {
        [TestMethod]
        public void TestConstruct()
        {
            var parser = new TestParser();

            Assert.IsTrue(parser is ISingleLineParser<string>);
        }

        [TestMethod]
        public void TestThatTryParseReturnsFalseOnNullString()
        {
            string result;
            var actual = new TestParser().TryParse(null, out result);

            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void TestThatTryParseReturnsFalseOnEmptyString()
        {
            string result;
            var actual = new TestParser().TryParse(string.Empty, out result);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void TestThatTryParseReturnsFalseOnWhiteSpaceString()
        {
            string result;
            var actual = new TestParser().TryParse("\t", out result);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void TestThatTryParseCallsAbstractParseMethodForMatchingPrefix()
        {
            string result;
            var parser = new TestParser();
            var actual = parser.TryParse(TestParser.Prefix + ":\t", out result);

            Assert.IsTrue(actual);
            Assert.IsTrue(parser.ParserCalled);
        }

        [TestMethod]
        public void TestThatTryParseDoesNotCallAbstractParseMethodForNonMatchingPrefix()
        {
            string result;
            var parser = new TestParser();
            var actual = parser.TryParse("xxy:\t", out result);

            Assert.IsFalse(actual);
            Assert.IsFalse(parser.ParserCalled);
        }

        private class TestParser : PrefixOnlyParser<string>
        {
            private const string prefix = "xxx";

            public TestParser()
                : base(prefix)
            {
            }

            public static string Prefix
            {
                get
                {
                    return prefix;
                }
            }

            public bool ParserCalled { get; set; }

            protected override bool TryParseWithoutPrefix(string lineWithoutPrefix, out string result)
            {
                result = null;
                this.ParserCalled = true;
                return true;
            }
        }
    }
}
