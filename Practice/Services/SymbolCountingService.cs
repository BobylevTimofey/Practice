using Practice.Interfaces;
using Practice.Models;

namespace Practice.Services
{
    public class SymbolCountingService : IAdditionalInfoService
    {
        public void AppendAdditionalInfo(ProcessedString processedString)
        {
            var countEachSymbols = new Dictionary<char, int>();
            foreach (var symbol in processedString.Result)
            {
                if (!countEachSymbols.ContainsKey(symbol))
                    countEachSymbols.Add(symbol, 1);
                else
                    countEachSymbols[symbol]++;
            }
            processedString.CountEachSymbols = countEachSymbols;
        }
    }
}
