using NUnit.Framework;
using Practice.Models;
using Practice.Services;

namespace Practice.Tests
{
    [TestFixture]
    public class StringProcessingServiceTests
    {
        [TestCase("a", "aa")]
        [TestCase("abcdef", "cbafed")]
        [TestCase("abcde", "edcbaabcde")]
        [TestCase("", "")]
        public void SimpleTest(string originalString, string expectedString)
        {
            var stringProcessing = new StringProcessingService();
            Assert.AreEqual(expectedString, stringProcessing.ProcessString(originalString).Value);
        }
    }
}
