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
        private readonly AggregatorAdditionalInformationServices aggregatorServices;

        public StringProcessingController(StringProcessingService stringProcessing,
            IValidator<string> validator, AggregatorAdditionalInformationServices aggregatorServices)
        {
            this.stringProcessing = stringProcessing;
            this.validator = validator;
            this.aggregatorServices = aggregatorServices;
        }

        [HttpPost]
        public IActionResult ProcessString([FromBody] string originalString, bool hasAdditionalInformation)
        {
            if (!validator.Validate(originalString))
                return BadRequest(validator.ErrorMessage);
            var processedString = stringProcessing.ProcessString(originalString);
            if (hasAdditionalInformation)
                return Ok(aggregatorServices.AppendAdditionalInformation(processedString));
            return Ok(processedString);
        }
    }
}
