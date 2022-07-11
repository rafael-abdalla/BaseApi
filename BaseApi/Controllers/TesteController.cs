using BaseApi.DTOs;
using BaseApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        private readonly IBaseService _service;

        public TesteController(IBaseService service) =>
            _service = service;

        [HttpPost]
        public async Task<IActionResult> Inserir([FromBody] InserirRegistroDto inserir)
        {
            await _service.Inserir(inserir);
            return Ok();
        }

        [HttpGet("validar-regra-de-negocio")]
        public IActionResult ValidarRegraDeNegocio()
        {
            _service.ValidarRegraDeNegocio();
            return Ok();
        }

        [HttpGet("buscar-registro")]
        public IActionResult BuscarRegistro()
        {
            _service.BuscarRegistro();
            return Ok();
        }
    }
}
