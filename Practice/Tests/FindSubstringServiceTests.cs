using NUnit.Framework;
using Practice.Models;
using Practice.Services.AdditionalInfoServices;

namespace Practice.Tests
{
    [TestFixture]
    public class FindSubstringServiceTests
    {
        private string? GetResult(string originalString)
        {
            var findSubstringService = new FindSubstringService();
            var processedString = new ProcessedString(originalString);
            findSubstringService.AppendAdditionalInfo(new Parameters(processedString));
            return processedString.Substring;
        }

        [Test]
        public void StringWithoutVowelsTest()
        {
            Assert.AreEqual("", GetResult("www"));
        }

        [Test]
        public void StringWithOneVowelTest()
        {
            Assert.AreEqual("a", GetResult("skfa"));
        }

        [Test]
        public void OneSubstringTest()
        {
            Assert.AreEqual("afe", GetResult("cbafed"));
        }

        [Test]
        public void StringWithMultipleSubstringsTest()
        {
            Assert.AreEqual("aabcudcsky", GetResult("aabcudcsky"));
        }
    }
}
