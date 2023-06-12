using Microsoft.AspNetCore.Mvc;
using Practice.Interfaces;
using Practice.Models;
using Practice.Services;

namespace Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StringProcessingController : Controller
    {
        private readonly StringProcessingService stringProcessing;
        private readonly IValidator<string> validator;
        private readonly IAdditionalInfoService<string, Dictionary<char, int>> additionalInfoService;

        public StringProcessingController(StringProcessingService stringProcessing,
            IValidator<string> validator, IAdditionalInfoService<string, Dictionary<char, int>> additionalInfoService)
        {
            this.stringProcessing = stringProcessing;
            this.validator = validator;
            this.additionalInfoService = additionalInfoService;
        }

        [HttpPost]
        public IActionResult ProcessString([FromBody] string originalString, bool hasAdditionalInformation)
        {
            if (!validator.Validate(originalString))
                return BadRequest(validator.ErrorMessage);
            var processedString = stringProcessing.ProcessString(originalString);
            if (hasAdditionalInformation)
            {
                var processedStringWithInfo = new ProcessedStringWithInfo<Dictionary<char, int>>(processedString.Value);
                processedStringWithInfo.AdditionalInfo = additionalInfoService.AppendAdditionalInfo(processedStringWithInfo.Value);
                return Ok(processedStringWithInfo);
            }
            return Ok(processedString);
        }
    }
}
