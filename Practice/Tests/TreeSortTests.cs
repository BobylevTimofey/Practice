using NUnit.Framework;
using Practice.Services.AdditionalInfoServices.Sortings;
using Practice.Services.AdditionalInfoServices.Sortings.TreeSort;

namespace Practice.Tests
{
    [TestFixture]
    public class TreeSortTests
    {
        [TestCase("bca", "abc")]
        [TestCase("a", "a")]
        [TestCase("dcba", "abcd")]
        public void SimpleTest(string originalString, string expectedString)
        {
            var originalArray = originalString.ToCharArray();
            var quickSort = new Services.AdditionalInfoServices.Sortings.TreeSort.TreeSort<char>();
            var sortedString = new string(quickSort.Sort(originalArray));
            Assert.AreEqual(expectedString, sortedString);
        }
    }
}
