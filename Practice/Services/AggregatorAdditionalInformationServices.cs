using Practice.Interfaces;
using Practice.Models;
using Practice.Services.AdditionalInfoServices;

namespace Practice.Services
{
    public class AggregatorAdditionalInformationServices
    {
        private readonly IEnumerable<IAdditionalInfoService> additionalInfoServices;

        public AggregatorAdditionalInformationServices(IEnumerable<IAdditionalInfoService> additionalInfoServices)
        {
            this.additionalInfoServices = additionalInfoServices;
        }

        public ProcessedString AppendAdditionalInformation(Parameters parameters)
        {
            foreach (var additionalInfoService in additionalInfoServices)
            {
                additionalInfoService.AppendAdditionalInfo(parameters);
            }
            return parameters.processedString;
        }
    }
}
