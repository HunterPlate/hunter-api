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

        [HttpGet("get-plates")]
        public async Task<IActionResult> GetPlate()
        {
            var result = await _registerPlatesService.GetPlate();

            return Ok(result);
        }

        [HttpDelete("delete-plates")]
        public async Task<IActionResult> DeletePlates([FromBody] List<DeletePlatesDataModelRequest> plates)
        {
            await _registerPlatesService.DeletePlates(plates);

            return Ok("Placas deletadas");
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
