using Barbearia23.Domain;
using Barbearia23.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Barbearia23.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly IServicoService _service;

        public ServicoController(IServicoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var servicos = await _service.ListarServicos();
            return Ok(servicos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var servicos = await _service.BuscarPorId(id);
            return Ok(servicos);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Servico servico)
        {
            var criado = await _service.Criar(servico);
            return CreatedAtAction(nameof(Get), new { id = servico.ServicoId }, criado);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Servico servico)
        {
            var criado = await _service.Atualizar(servico);
            return Ok(criado);

        }

        [HttpDelete]
        public async Task<IActionResult> ActionResult(int id)
        {
            var existente = await _service.BuscarPorId(id);

            if (existente == null)
                return NotFound("Servico não encontrado");

            await _service.Remover(id);

            return NoContent();
        }
    }
}
