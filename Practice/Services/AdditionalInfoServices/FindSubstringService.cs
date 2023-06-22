using Practice.Interfaces;
using Practice.Models;

namespace Practice.Services.AdditionalInfoServices
{
    public class FindSubstringService : IAdditionalInfoService
    {
        private char[] extremeLetters = new char[] { 'a', 'e', 'i', 'o', 'u', 'y' };
        public void AppendAdditionalInfo(Parameters parameters)
        {
            var startPosition = FindStartPosition(parameters.processedString);
            if (startPosition == -1)
            {
                parameters.processedString.Substring = "";
                return;
            }
            var endPosition = FindEndPosition(parameters.processedString, startPosition);
            parameters.processedString.Substring = parameters.processedString.Result.Substring(startPosition, endPosition - startPosition + 1);
        }

        private int FindStartPosition(ProcessedString value)
        {
            for (var i = 0; i < value.Result.Length; i++)
            {
                if (extremeLetters.Contains(value.Result[i]))
                    return i;
            }
            return -1;
        }

        private int FindEndPosition(ProcessedString value, int startPosition)
        {
            var endPosition = startPosition;
            for (var i = startPosition; i < value.Result.Length; i++)
            {
                if (extremeLetters.Contains(value.Result[i]))
                    endPosition = i;
            }
            return endPosition;
        }
    }
}
