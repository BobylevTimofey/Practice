using Practice.Interfaces;
using System.Text;

namespace Practice.Services
{
    public class ValidationService<T>
    {
        private readonly IEnumerable<IValidator<T>> validators;
        public string? ErrorMessages { get; set; }
        public ValidationService(IEnumerable<IValidator<T>> validators)
        {
            this.validators = validators;
        }

        public bool Validate(T value)
        {
            var stringBuilder = new StringBuilder();
            var result = true;
            foreach (var validator in validators)
            {
                if (!validator.Validate(value))
                {
                    stringBuilder.Append(validator.ErrorMessage);
                    result = false;
                }
            }
            ErrorMessages = stringBuilder.ToString();
            return result;
        }
    }
}
