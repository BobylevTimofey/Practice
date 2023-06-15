using Practice.Interfaces;
using Practice.Models;

namespace Practice.Services
{
    public class AggregatorAdditionalInformationServices
    {
        private readonly IEnumerable<IAdditionalInfoService> additionalInfoServices;

        public AggregatorAdditionalInformationServices(IEnumerable<IAdditionalInfoService> additionalInfoServices)
        {
            this.additionalInfoServices = additionalInfoServices;
        }

        public ProcessedString AppendAdditionalInformation(ProcessedString processedString)
        {
            foreach (var additionalInfoService in additionalInfoServices)
            {
                additionalInfoService.AppendAdditionalInfo(processedString);
            }
            return processedString;
        }
    }
}
