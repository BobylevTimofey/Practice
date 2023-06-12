using Practice.Interfaces;

namespace Practice.Models
{
    public class ProcessedStringWithInfo<TInfo> : ProcessedString
    {
        public ProcessedStringWithInfo(string value) : base(value)
        {
        }

        public TInfo? AdditionalInfo { get; set; }
    }
}
