using Practice.Interfaces;
using Practice.Models;

namespace Practice.Services
{
    public class FindSubstringService : IAdditionalInfoService
    {
        private char[] extremeLetters = new char[] { 'a', 'e', 'i', 'o', 'u', 'y' };
        public void AppendAdditionalInfo(ProcessedString value)
        {
            var startPosition = FindStartPosition(value);
            if (startPosition == -1)
            {
                value.substring = "";
                return;
            }
            var endPosition = FindEndPosition(value, startPosition);
            value.substring = value.Result.Substring(startPosition, endPosition - startPosition + 1);
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
