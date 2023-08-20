using Practice.Interfaces;

namespace Practice.Services.Validators
{
    public class NullStringValidator : IValidator<string>
    {
        public string? ErrorMessage { get; set; }

        public bool Validate(string value)
        {
            if (value == null)
            {
                ErrorMessage = "The string must not be null.";
                return false;
            }
            return true;
        }
    }
}
