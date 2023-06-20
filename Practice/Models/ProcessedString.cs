using Practice.Interfaces;

namespace Practice.Models
{
    public class ProcessedString
    {
        public ProcessedString(string result)
        {
            Result = result;
        }

        public string Result { get; set; }
        public Dictionary<char, int>? CountEachSymbols { get; set; }
        public string? Substring { get; set; }
        public string? SortedResult { get; set; }
    }
}
