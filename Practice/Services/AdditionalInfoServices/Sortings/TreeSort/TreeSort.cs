using Practice.Interfaces;

namespace Practice.Services.AdditionalInfoServices.Sortings.TreeSort
{
    public class TreeSort<T> : ISorter<T>
        where T : IComparable
    {
        public SorterName Name => SorterName.TreeSort;

        public T[] Sort(T[] array)
        {
            var treeNode = new TreeNode<T>(array[0]);
            for(var i = 1; i < array.Length; i++)
                treeNode.Insert(new TreeNode<T>(array[i]));
            return treeNode.Printout();
        }
    }
}
