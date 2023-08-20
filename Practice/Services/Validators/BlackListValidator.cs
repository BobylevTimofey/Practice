using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Practice.Interfaces;
using System.Text;

namespace Practice.Services.Validators
{
    public class BlackListValidator : IValidator<string>
    {
        private readonly IConfiguration configuration;

        public BlackListValidator(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string? ErrorMessage { get; set; }

        public bool Validate(string value)
        {
            var blackList = configuration.GetSection("Settings")
                                         .GetSection("BlackList")
                                         .GetChildren()
                                         .Select(x => x.Value)
                                         .ToList();

            return CheckBlackList(value, blackList);
        }

        private bool CheckBlackList(string value, List<string> blackList)
        {
            var result = true;
            var errorMessage = new StringBuilder();

            foreach (var blackString in blackList)
            {
                if (blackString == value)
                {
                    result = false;
                    ErrorMessage = "The string is in the black list.";
                    break;
                }
            }

            return result;
        }
    }
}
