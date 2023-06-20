using Practice.Interfaces;

namespace Practice.Services.AdditionalInfoServices.Sortings
{
    public class QuickSort<T> : ISorter<T>
        where T : IComparable
    {
        public SorterName Name => SorterName.QuickSort;

        public T[] Sort(T[] array)
        {
            return Sort(array, 0, array.Length - 1);
        }

        private T[] Sort(T[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
                return array;

            var pivot = FindPivot(array, minIndex, maxIndex);
            Sort(array, minIndex, pivot - 1);
            Sort(array, pivot + 1, maxIndex);

            return array;
        }

        private int FindPivot(T[] arrray, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (arrray[i].CompareTo(arrray[maxIndex]) < 0)
                {
                    pivot++;
                    Swap(arrray, pivot, i);
                }
            }

            pivot++;
            Swap(arrray, pivot, maxIndex);

            return pivot;
        }

        private void Swap(T[] arrray, int pivot, int index)
        {
            var temp = arrray[pivot];
            arrray[pivot] = arrray[index];
            arrray[index] = temp;
        }
    }
}
