using Practice.Interfaces;
using Practice.Models;
using Practice.Services.AdditionalInfoServices.Sortings;

namespace Practice.Services.AdditionalInfoServices
{
    public class SortingService : IAdditionalInfoService
    {
        private readonly IEnumerable<ISorter<char>> sotrings;
        public SortingService(IEnumerable<ISorter<char>> sotrings)
        {
            this.sotrings = sotrings;
        }

        public void AppendAdditionalInfo(Parameters parameters)
        {
            var sorting = sotrings
                .Where(sorting => sorting.Name == parameters.SorterName)
                .FirstOrDefault();
            if (sorting != null)
            {
                var resultInCharArray = parameters.processedString.Result.ToCharArray();
                parameters.processedString.SortedResult = new string(sorting.Sort(resultInCharArray));
            }
            else 
                throw new NullReferenceException($"Sorting by name {parameters.SorterName} not found");
        }
    }
}
