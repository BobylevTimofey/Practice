using Practice.Services.AdditionalInfoServices.Sortings;

namespace Practice.Interfaces
{
    public interface ISorter<T>
        where T : IComparable
    {
        public SorterName Name { get; }
        public T[] Sort(T[] array);
    }
}
