using Barbearia23.Domain;
using Barbearia23.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Barbearia23.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clientes = await _service.ListarClientes();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var clientes = await _service.BuscarPorId(id);
            return Ok(clientes);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Cliente cliente)
        {
            var criado = await _service.Criar(cliente);
            return CreatedAtAction(nameof(Get), new { id = cliente.ClienteId }, criado);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Cliente cliente)
        {
            var criado = await _service.Atualizar(cliente);
            return Ok(criado);

        }

        [HttpDelete]
        public async Task<IActionResult> ActionResult(int id)
        {
            var existente = await _service.BuscarPorId(id);

            if (existente == null)
                return NotFound("Cliente não encontrado");

           await _service.Remover(id);

             return NoContent();
        }
    }
}
