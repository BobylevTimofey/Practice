using Microsoft.AspNetCore.Mvc;
using Practice.Interfaces;
using Practice.Services;

namespace Practice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StringProcessingController : Controller
    {
        private readonly StringProcessingService stringProcessing;
        private readonly IValidator<string> validator;

        public StringProcessingController(StringProcessingService stringProcessing, IValidator<string> validator)
        {
            this.stringProcessing = stringProcessing;
            this.validator = validator;
        }

        [HttpPost]
        public IActionResult ProcessString([FromBody] string originalString)
        {
            if(!validator.Validate(originalString))
                return BadRequest(validator.ErrorMessage);
            return Ok(stringProcessing.ProcessString(originalString));
        }
    }
}
