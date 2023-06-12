using Practice.Interfaces;
using Practice.Models;

namespace Practice.Services
{
    public class SymbolCountingService : IAdditionalInfoService<string, Dictionary<char, int>>
    {
        public Dictionary<char, int> AppendAdditionalInfo(string value)
        {
            var countRepeatSymbols = new Dictionary<char, int>();
            foreach (var symbol in value)
            {
                if (!countRepeatSymbols.ContainsKey(symbol))
                    countRepeatSymbols.Add(symbol, 1);
                else
                    countRepeatSymbols[symbol]++;
            }
            return countRepeatSymbols;
        }
    }
}
