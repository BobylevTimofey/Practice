using Practice.Models;
using Practice.Services.AdditionalInfoServices;
using System.Reflection.Metadata;

namespace Practice.Interfaces
{
    public interface IAdditionalInfoService
    {
        public void AppendAdditionalInfo(Parameters parameters);
    }
}
