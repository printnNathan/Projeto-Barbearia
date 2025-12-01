using Barbearia23.Domain;
using Barbearia23.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Barbearia23.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static Cliente cliente = new Cliente();

        [HttpPost("register")]
        public ActionResult<Cliente> Registro(ClienteDTO request)
        {
            var hashedPassowrd = new PasswordHasher<Cliente>()
                 .HashPassword(cliente, request.Senha);

            cliente.Nome = request.Nome;
            cliente.Senha = hashedPassowrd;

            return Ok(cliente);
        }

        [HttpPost("login")]
        public ActionResult<string> Login(ClienteDTO request)
        {
            if (request.Nome != cliente.Nome)
            {
                return BadRequest("Usuário não encontrado.");
            }
            if (new PasswordHasher<Cliente>().VerifyHashedPassword(cliente, cliente.Pass, request.Senha))
                == PasswordVerificationResult.Failed)
                {
                    
                }
        }

        //https://youtu.be/6EEltKS8AwA?si=4OS70uUcPyoR6H2L
    }
}
