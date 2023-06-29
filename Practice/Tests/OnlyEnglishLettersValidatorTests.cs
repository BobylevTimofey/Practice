using NUnit.Framework;
using Practice.Services;
using Practice.Services.Validators;

namespace Practice.Tests
{
    [TestFixture]
    public class OnlyEnglishLettersValidatorTests
    {
        OnlyEnglishLettersValidator lettersValidator = new OnlyEnglishLettersValidator();

        [Test]
        public void CorrectTest()
        {
            var correctString = "sdfkl";
            Assert.AreEqual(true, lettersValidator.Validate(correctString));
        }

        [TestCase("123", "Contains invalid characters: \'1\' \'2\' \'3\'.")]
        [TestCase("abcd.ef", "Contains invalid characters: \'.\'.")]
        [TestCase("ллл", "Contains invalid characters: \'л\'.")]
        [TestCase("лsdfcг", "Contains invalid characters: \'л\' \'г\'.")]
        public void InvalidCharactersTest(string originalString, string expectedErrorMessage)
        {
            Assert.AreEqual(false, lettersValidator.Validate(originalString));
            Assert.AreEqual(expectedErrorMessage, lettersValidator.ErrorMessage);
        }
    }
}
