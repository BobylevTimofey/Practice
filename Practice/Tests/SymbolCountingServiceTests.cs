using NUnit.Framework;
using Practice.Services;
using System.Globalization;

namespace Practice.Tests
{
    [TestFixture]
    public class SymbolCountingServiceTests
    {
        private Dictionary<char, int> GetResult(string originalString)
        {
            var symbolCounting = new SymbolCountingService();
            return symbolCounting.AppendAdditionalInfo(originalString);
        }

        [Test]
        public void OneSymbolTest()
        {
            var expectedDictionary = new Dictionary<char, int>() { { 'a', 1 } };
            Assert.AreEqual(expectedDictionary, GetResult("a"));
        }

        [Test]
        public void SeveralDifferentSymbolsTest()
        {
            var expectedDictionary = new Dictionary<char, int>() { { 'a', 1 }, { 'b', 1 }, { 'c', 1 } };
            Assert.AreEqual(expectedDictionary, GetResult("abc"));
        }

        [Test]
        public void SeveralSameSymbolsTest()
        {
            var expectedDictionary = new Dictionary<char, int>() { { 'a', 3 }, { 'b', 2 } };
            Assert.AreEqual(expectedDictionary, GetResult("aaabb"));
        }
    }
}
