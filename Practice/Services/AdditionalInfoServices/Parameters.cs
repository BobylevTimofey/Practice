using Practice.Models;
using Practice.Services.AdditionalInfoServices.Sortings;

namespace Practice.Services.AdditionalInfoServices
{
    public class Parameters
    {
        public Parameters(ProcessedString processedString)
        {
            this.processedString = processedString;
        }

        public ProcessedString processedString { get; set; }
        public SorterName SorterName { get; set; }
    }
}
