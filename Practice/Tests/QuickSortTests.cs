using NUnit.Framework;
using Practice.Services.AdditionalInfoServices.Sortings;

namespace Practice.Tests
{
    [TestFixture]
    public class QuickSortTests
    {
        [TestCase("bca", "abc")]
        [TestCase("a", "a")]
        [TestCase("dcba", "abcd")]
        public void SimpleTest(string originalString, string expectedString)
        {
            var originalArray = originalString.ToCharArray();
            var quickSort = new QuickSort<char>();
            var sortedString = new string(quickSort.Sort(originalArray));
            Assert.AreEqual(expectedString, sortedString);
        }
    }
}
