using Barbearia23.Domain;
using Barbearia23.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Barbearia23.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarbeiroController : ControllerBase
    {
        private readonly IBarbeiroService _service;

        public BarbeiroController(IBarbeiroService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var barbeiros = await _service.ListarBarbeiros();
            return Ok(barbeiros);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var barbeiros = await _service.BuscarPorId(id);
            return Ok(barbeiros);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Barbeiro barbeiro)
        {
            var criado = await _service.Criar(barbeiro);
            return CreatedAtAction(nameof(Get), new { id = barbeiro.BarbeiroId }, criado);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Barbeiro barbeiro)
        {
            var criado = await _service.Atualizar(barbeiro);
            return Ok(criado);

        }

        [HttpDelete]
        public async Task<IActionResult> ActionResult(int id)
        {
            var existente = await _service.BuscarPorId(id);

            if (existente == null)
                return NotFound("Barbeiro não encontrado");

            await _service.Remover(id);

            return NoContent();
        }

    }
}
