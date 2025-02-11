using hunter_api.Interfaces;
using hunter_api.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace hunter_api.Controllers
{
    [ApiController]
    [Route("register")]
    public class RegisterController : Controller
    {

        private readonly IRegisterPlatesService _registerPlatesService;

        public RegisterController(IRegisterPlatesService registerPlatesService)
        {
            _registerPlatesService = registerPlatesService;
        }

        [HttpPost("register-plate")]
        public async Task<IActionResult> CreatePlate(
            [FromBody] List<PlatesDataRequest> plates)
        {
            var result = _registerPlatesService.RegisterPlates(plates);

            return Ok(result);
        }
    }
}
