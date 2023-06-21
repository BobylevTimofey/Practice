using Practice.Interfaces;

namespace Practice.Services.AdditionalInfoServices
{
    public class SymbolRemoveService : IAdditionalInfoService
    {
        private readonly IHttpClientFactory clientFactory;

        public SymbolRemoveService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public void AppendAdditionalInfo(Parameters parameters)
        {
            var result = GetStringWithoutSymbol(parameters.processedString.Result);
            parameters.processedString.ResultWithoutSymbol = result;
        }

        private int GetIndexFromGenerator(int lengthArray)
        {
            var rnd = new Random();
            return rnd.Next(lengthArray);
        }

        private async Task<int> GetIndexFromWebApiAsync(int lengthArray)
        {
            var client = clientFactory.CreateClient();
            var response = await client.GetStringAsync(
                $"https://www.random.org/integers/?num=1&min=0&max={lengthArray - 1}&col=1&base=10&format=plain&rnd=new");
            return int.Parse(response);
        }

        private string GetStringWithoutSymbol(string value, int countSymbols = 1)
        {
            var index = -1;
            try
            {
                index = GetIndexFromWebApiAsync(value.Length).Result;
            }
            catch
            {
                index = GetIndexFromGenerator(value.Length);
            }

            return value.Remove(index, countSymbols);
        }
    }
}
