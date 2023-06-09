using NUnit.Framework;
using Practice.Services;

namespace Practice.Tests
{
    [TestFixture]
    public class ValidatorTests
    {
        [Test]
        public void NullStringTest()
        {
            var validator = new OnlyEnglishLettersValidator();
            Assert.AreEqual(false, validator.Validate(null));
        }

        [Test]
        public void EmptyStringTest()
        {
            var validator = new OnlyEnglishLettersValidator();
            Assert.AreEqual(false, validator.Validate(""));
        }

        [Test]
        public void CorrectTest()
        {
            var validator = new OnlyEnglishLettersValidator();
            Assert.AreEqual(true, validator.Validate("qwerty"));
        }

        [TestCase("123", "Contains invalid characters: \'1\' \'2\' \'3\'")]
        [TestCase("abcd.ef", "Contains invalid characters: \'.\'")]
        [TestCase("ллл", "Contains invalid characters: \'л\'")]
        public void InvalidCharactersTest(string originalString, string expectedErrorMessage)
        {
            var validator = new OnlyEnglishLettersValidator();
            Assert.AreEqual(false, validator.Validate(originalString));
            Assert.AreEqual(expectedErrorMessage, validator.ErrorMessage);
        }
    }
}
