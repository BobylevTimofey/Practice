using Microsoft.AspNetCore.Mvc;
using Practice.Interfaces;
using Practice.Models;
using Practice.Services;
using Practice.Services.AdditionalInfoServices;
using Practice.Services.AdditionalInfoServices.Sortings;
using System.Reflection.Metadata;

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

        /// <summary> process the string </summary>
        /// <param name="originalString">string to be processed</param>
        /// <param name="sorterName">Selection of the sorting used</param>
        /// <returns>Processed string with additional information</returns>
        /// <response code="200">Returns the processed string with additional information</response>
        /// <response code="400">If the string is null, empty or contains invalid symbols</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProcessedString))]
        public IActionResult ProcessString(string originalString, SorterName sorterName)
        {
            if (!validator.Validate(originalString))
                return BadRequest(validator.ErrorMessage);
            var processedString = stringProcessing.ProcessString(originalString);
            var parameters = new Parameters(processedString) { SorterName = sorterName };
            return Ok(aggregatorServices.AppendAdditionalInformation(parameters));
        }
    }
}
