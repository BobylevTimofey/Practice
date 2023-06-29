using NUnit.Framework;
using Practice.Interfaces;
using Practice.Services.AdditionalInfoServices.Sortings;
using Practice.Services.AdditionalInfoServices.Sortings.TreeSort;

namespace Practice.Tests
{
    [TestFixture]
    public class SortTests
    {
        private T[] GetSortedValue<T>(T[] originalValue, ISorter<T> sorter)
            where T : IComparable
        {
            return sorter.Sort(originalValue);
        }

        [TestCase(new char[] { 'b', 'c', 'a' }, new char[] { 'a', 'b', 'c' })]
        [TestCase(new char[] { 'a' }, new char[] { 'a' })]
        [TestCase(new char[] { 'd', 'c', 'b', 'a' }, new char[] { 'a', 'b', 'c', 'd' })]
        [TestCase(new char[] { }, new char[] { })]
        public void SimpleQuickSortCharTest(char[] originalCharArray, char[] expectedCharArray)
        {
            Assert.AreEqual(expectedCharArray, GetSortedValue(originalCharArray, new QuickSort<char>()));
        }

        [TestCase(new char[] { 'b', 'c', 'a' }, new char[] { 'a', 'b', 'c' })]
        [TestCase(new char[] { 'a' }, new char[] { 'a' })]
        [TestCase(new char[] { 'd', 'c', 'b', 'a' }, new char[] { 'a', 'b', 'c', 'd' })]
        [TestCase(new char[] { }, new char[] { })]
        public void SimpleTreeSortCharTest(char[] originalCharArray, char[] expectedString)
        {
            Assert.AreEqual(expectedString, GetSortedValue(originalCharArray, new TreeSort<char>()));
        }

        [TestCase(new int[] { 2, 3, 1 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 4, 3, 2, 1 }, new int[] { 1, 2, 3, 4 })]
        public void SimpleQuickSortIntTest(int[] originalIntArray, int[] expectedIntArray)
        {
            Assert.AreEqual(expectedIntArray, GetSortedValue(originalIntArray, new QuickSort<int>()));
        }

        [TestCase(new int[] { 2, 3, 1 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 4, 3, 2, 1 }, new int[] { 1, 2, 3, 4 })]
        public void SimpleTreeSortIntTest(int[] originalIntArray, int[] expectedIntArray)
        {
            Assert.AreEqual(expectedIntArray, GetSortedValue(originalIntArray, new TreeSort<int>()));
        }
    }
}
