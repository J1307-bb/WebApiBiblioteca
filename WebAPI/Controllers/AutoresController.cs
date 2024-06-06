using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoresController : ControllerBase
    {
        public readonly IAutorService _autorService;
        public AutoresController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        [HttpGet]
        public async Task<IActionResult> ObternerAutores()
        {
            var result = await _autorService.GetAutores();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CrearAutor([FromBody] Autor request)
        {
            var result = await _autorService.Crear(request);
            return Ok(result);

        }

        [HttpPut("id")]
        public async Task<IActionResult> EditarAutor([FromBody] Autor request, int id)
        {
            var result = await _autorService.Actualizar(id, request);
            return Ok(result);

        }

        [HttpDelete("id")]
        public async Task<IActionResult> EliminarAutor(int id)
        {
            var result = await _autorService.Eliminar(id);
            return Ok(result);

        }

    }
}
