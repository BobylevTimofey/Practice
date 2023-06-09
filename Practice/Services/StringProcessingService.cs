using System.Text;

namespace Practice.Services
{
    public class StringProcessingService
    {
        public string ProcessString(string originalString)
        {
            if (originalString.Length % 2 == 0)
                return ProcessEvenLengthString(originalString.ToCharArray());
            else
                return ProcessOddLengthString(originalString.ToCharArray());
        }

        private string ProcessEvenLengthString(char[] charArray)
        { 
            var firstPart = charArray.Take(charArray.Length / 2)
                                     .Reverse();
            var secondPart = charArray.Skip(charArray.Length / 2)
                                      .Reverse();
     
            return new string(firstPart.Concat(secondPart).ToArray());                
        }

        private string ProcessOddLengthString(char[] charArray)
        {
            var firstPart = charArray.Reverse();
            return new string(firstPart.Concat(charArray).ToArray());             
        }
    }
}
