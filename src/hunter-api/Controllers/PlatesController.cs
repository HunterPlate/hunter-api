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
            [FromBody] List<PlatesDataModelRequest> plates)
        {
            var result = await _registerPlatesService.RegisterPlates(plates);
            if (!result)
            {
                return BadRequest("Error: Placas não cadastradas");
            }

            return Ok("Placas Cadastradas");
        }

        [HttpGet("get-plate")]
        public async Task<IActionResult> GetPlate(
            [FromQuery] string plates)
        {
            var result = await _registerPlatesService.GetPlate(plates);

            return Ok(result);
        }

        [HttpPost("upload-sheet")]
        public async Task<IActionResult> UploadExcel(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Nenhum inválido.");

            try
            {
                var result = await _registerPlatesService.InsertTablePlates(file);
                if (!result)
                {
                    return BadRequest("Error: Placas não cadastradas");
                }

                return Ok("Placas Cadastradas");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao processar o arquivo: {ex.Message}");
            }
        }
    }
}
