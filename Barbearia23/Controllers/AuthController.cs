using Barbearia23.Domain;
using Barbearia23.Infra.Context;
using Barbearia23.Models;
using Barbearia23.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Barbearia23.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly BarbeariaContext _context;
        public AuthController(BarbeariaContext context)
        {
            _context = context;
        }

        public static Cliente cliente = new Cliente();

        [HttpPost("register")]
        public ActionResult<Cliente> Registro(ClienteDTO request)
        {
            var hashedPassowrd = new PasswordHasher<Cliente>()
                 .HashPassword(cliente, request.Senha);

            cliente.Nome = request.Nome;
            cliente.PasswordHash = hashedPassowrd;

            return Ok(cliente);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(ClienteDTO request)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Nome == request.Nome);

            if (cliente == null)
            {
                return BadRequest("Usuário não encontrado.");
            }
            if (new PasswordHasher<Cliente>().VerifyHashedPassword(cliente, cliente.PasswordHash, request.Senha)
                == PasswordVerificationResult.Failed)
            {
                return BadRequest("Senha incorreta.");
            }

            string token = "success";

            return Ok(token);
        }

        //https://youtu.be/6EEltKS8AwA?si=4OS70uUcPyoR6H2L
    }
}
