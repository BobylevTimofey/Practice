using Practice.Interfaces;
using Practice.Models;

namespace Practice.Services.AdditionalInfoServices
{
    public class SymbolCountingService : IAdditionalInfoService
    {
        public void AppendAdditionalInfo(Parameters parameters)
        {
            var countEachSymbols = new Dictionary<char, int>();
            foreach (var symbol in parameters.processedString.Result)
            {
                if (!countEachSymbols.ContainsKey(symbol))
                    countEachSymbols.Add(symbol, 1);
                else
                    countEachSymbols[symbol]++;
            }
            parameters.processedString.CountEachSymbols = countEachSymbols;
        }
    }
}
