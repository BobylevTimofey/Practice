using NUnit.Framework;
using Practice.Services;

namespace Practice.Tests
{
    [TestFixture]
    public class StringProcessingServiceTests
    {
        private StringProcessingService stringProcessing = new StringProcessingService();

        [TestCase("abcdef", "cbafed")]
        [TestCase("kfrd", "fkdr")]
        public void EvenNumberSymbolsTest(string originalString, string expectedString)
        {
     
            Assert.AreEqual(expectedString, stringProcessing.ProcessString(originalString).Result);
        }

        [TestCase("a", "aa")]
        [TestCase("abcde", "edcbaabcde")]
        public void OddNumberSymbolsTest(string originalString, string expectedString)
        {

            Assert.AreEqual(expectedString, stringProcessing.ProcessString(originalString).Result);
        }

        [Test]
        public void EmptyStringTest()
        {
            var originalString = "";
            var expectedString = "";
            Assert.AreEqual(expectedString, stringProcessing.ProcessString(originalString).Result);
        }
    }
}
