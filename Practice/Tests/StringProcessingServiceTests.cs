using NUnit.Framework;
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
        [TestCase("34", "43")]
        public void SimpleTest(string originalString, string expectedString)
        {
            var stringProcessing = new StringProcessingService();
            Assert.AreEqual(expectedString, stringProcessing.ProcessString(originalString));
        }

        [Test]
        public void ExceptionTest()
        {
            var stringProcessing = new StringProcessingService();
            string? originalString = null;
            Assert.Throws(Is.AssignableTo(typeof(NullReferenceException)),() => stringProcessing.ProcessString(originalString));
        }
    }
}
