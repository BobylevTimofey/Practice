using Microsoft.AspNetCore.Mvc;
using Practice.Services;

namespace Practice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StringProcessingController : Controller
    {
        private readonly StringProcessingService stringProcessing;

        public StringProcessingController(StringProcessingService stringProcessing)
        {
            this.stringProcessing = stringProcessing;
        }

        [HttpPost]
        public string? Index([FromBody] string originalString)
        {
            return stringProcessing.ProcessString(originalString);
        }
    }
}
