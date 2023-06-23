using NUnit.Framework;
using Practice.Services;
using Practice.Services.Validators;

namespace Practice.Tests
{
    [TestFixture]
    public class ValidatorTests
    {
        [Test]
        public void NullStringTest()
        {
            var validator = new NullStringValidator();
            Assert.AreEqual(false, validator.Validate(null));
        }

        [Test]
        public void EmptyStringTest()
        {
            var validator = new EmptyStringValidator();
            Assert.AreEqual(false, validator.Validate(""));
        }

        [Test]
        public void CorrectTest()
        {
            var correctString = "sdfkl";
            var lettersValidator = new OnlyEnglishLettersValidator();
            var nullValidator = new NullStringValidator();
            var emptyValidator = new EmptyStringValidator();
            Assert.AreEqual(true, lettersValidator.Validate(correctString));
            Assert.AreEqual(true, nullValidator.Validate(correctString));
            Assert.AreEqual(true, emptyValidator.Validate(correctString));
        }

        [TestCase("123", "Contains invalid characters: \'1\' \'2\' \'3\'.")]
        [TestCase("abcd.ef", "Contains invalid characters: \'.\'.")]
        [TestCase("ллл", "Contains invalid characters: \'л\'.")]
        public void InvalidCharactersTest(string originalString, string expectedErrorMessage)
        {
            var validator = new OnlyEnglishLettersValidator();
            Assert.AreEqual(false, validator.Validate(originalString));
            Assert.AreEqual(expectedErrorMessage, validator.ErrorMessage);
        }
    }
}
