using Practice.Interfaces;

namespace Practice.Models
{
    public class ProcessedString
    {
        public string Value { get; init; }

        public ProcessedString(string value)
        {
            Value = value;
        }
    }
}
