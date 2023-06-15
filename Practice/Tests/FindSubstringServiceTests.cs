using NUnit.Framework;
using Practice.Models;
using Practice.Services;

namespace Practice.Tests
{
    [TestFixture]
    public class FindSubstringServiceTests
    {
        private string GetResult(string originalString)
        {
            var findSubstringService = new FindSubstringService();
            var processedString = new ProcessedString(originalString);
            findSubstringService.AppendAdditionalInfo(processedString);
            return processedString.substring;
        }

        [TestCase("aa", "aa")]
        [TestCase("cbafed", "afe")]
        [TestCase("edcbaabcde", "edcbaabcde")]
        [TestCase("vvv", "")]
        public void SimpleTest(string originalString, string expectedSubstring)
        {
            Assert.AreEqual(expectedSubstring, GetResult(originalString));
        }
    }
}
