using NUnit.Framework.Internal.Execution;
using Practice.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Practice.Services
{
    public class OnlyEnglishLettersValidator : IValidator<string>
    {
        public string? ErrorMessage { get; set; }

        public bool Validate(string value)
        {
            if (value == null)
            {
                ErrorMessage = "The string must not be null";
                return false;
            }

            if (value.Length == 0)
            {
                ErrorMessage = "The string must not be empty";
                return false;
            }

            return ValidateSymbols(value.ToCharArray());
        }

        private bool ValidateSymbols(char[] value)
        {
            var errorSymbols = value.Where(symbol => symbol < 'a' || symbol > 'z')
                .Distinct();
            if (errorSymbols.Count() == 0)
                return true;
            GenerateErrorMessage(errorSymbols);
            return false;

        }

        private void GenerateErrorMessage(IEnumerable<char> errorSymbols)
        {
            var errorMessage = new StringBuilder();
            errorMessage.Append("Contains invalid characters:");
            foreach (var symbol in errorSymbols)
            {
                errorMessage.Append(' ');
                errorMessage.Append('\'');
                errorMessage.Append(symbol);
                errorMessage.Append('\'');
            }

            ErrorMessage = errorMessage.ToString();
        }
    }
}
