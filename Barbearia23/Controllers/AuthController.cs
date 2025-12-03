using Barbearia23.Domain;
using Barbearia23.Infra.Context;
using Barbearia23.Models;
using Barbearia23.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia23.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly BarbeariaContext _context;
        private readonly IConfiguration _config;
        private readonly PasswordHasher<Cliente> _hasher = new PasswordHasher<Cliente>();

        public AuthController(BarbeariaContext context, IConfiguration config)
        {
            _context = context;
            //_hasher = new PasswordHasher<Cliente>();
            _config = config;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Registrar(ClienteDTO request)
        {
            if(string.IsNullOrWhiteSpace(request.Nome) ||
               string.IsNullOrWhiteSpace(request.Senha))
               return BadRequest("Nome e Senha são obrigatórios.");

            var existe = await _context.Clientes.AnyAsync(c => c.Nome == request.Nome); //Erro nesta linha
            if ( existe )
                return BadRequest("Nome de usuário já existe.");

            var cliente = new Cliente
            {
                Nome = request.Nome,
                Senha = request.Senha,
                Ativo = request.Ativo
            };

            cliente.PasswordHash = _hasher.HashPassword(cliente, request.Senha);

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return Ok("Usuário registrado com sucesso.");
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(Cliente request)
        {
            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(c => c.Nome == request.Nome);

            if ( cliente == null)
                return BadRequest("Usuário não encontrado.");

            var result = _hasher.VerifyHashedPassword(cliente, cliente.PasswordHash, request.Senha);

            if (result != PasswordVerificationResult.Success)
                return BadRequest("Senha incorreta");

            string token = GerarToken(cliente);
            return Ok(token);
        }

        private string GerarToken(Cliente cliente)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, cliente.Nome),
                new Claim("ClienteId", cliente.ClienteId.ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"])
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
