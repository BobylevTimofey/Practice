using Practice.Interfaces;

namespace Practice.Services.Validators
{
    public class EmptyStringValidator : IValidator<string>
    {
        public string? ErrorMessage { get; set; }

        public bool Validate(string value)
        {
            if (value.Length == 0)
            {
                ErrorMessage = "The string must not be empty.";
                return false;
            }
            return true;
        }
    }
}
