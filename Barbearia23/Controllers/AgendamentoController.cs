using Barbearia23.Domain;
using Barbearia23.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Barbearia23.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoService _service;

        public AgendamentoController(IAgendamentoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var agendamento = await _service.ListarAgendamentos();
            return Ok(agendamento);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var agendamento = await _service.BuscarPorId(id);
            return Ok(agendamento);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Agendamento agendamento)
        {
            var criado = await _service.Criar(agendamento);
            return CreatedAtAction(nameof(Get), new { id = agendamento.AgendamentoId }, criado);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Agendamento agendamento)
        {
            var criado = await _service.Atualizar(agendamento);
            return Ok(criado);

        }

        [HttpDelete]
        public async Task<IActionResult> ActionResult(int id)
        {
            var existente = await _service.BuscarPorId(id);

            if (existente == null)
                return NotFound("Agendamento não encontrado");

            await _service.Remover(id);

            return NoContent();
        }

    }
}
