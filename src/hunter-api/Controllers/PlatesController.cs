using hunter_api.Interfaces;
using hunter_api.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace hunter_api.Controllers
{
    [ApiController]
    [Route("plates")]
    public class PlatesController : Controller
    {

        private readonly IRegisterPlatesService _registerPlatesService;

        public PlatesController(IRegisterPlatesService registerPlatesService)
        {
            _registerPlatesService = registerPlatesService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreatePlate(
            [FromBody] List<PlatesDataRequest> plates)
        {
            var result = _registerPlatesService.RegisterPlates(plates);

            return Ok(result);
        }

        [HttpPost("get-plate")]
        public async Task<IActionResult> GetPlate(
            [FromQuery] string plates)
        {
            var result = _registerPlatesService.GetPlate(plates);

            return Ok(result);
        }
    }
}
