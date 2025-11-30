using Barbearia23.Domain;
using Barbearia23.Infra.Repositories.Interfaces;
using Barbearia23.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Barbearia23.Services.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repo;

        public ClienteService(IClienteRepository repo)
        {
            _repo = repo;
        }


        public async Task<IEnumerable<Cliente>> ListarClientes()
        {
            return await _repo.BuscarClientes();
        }
        public Task<Cliente?> BuscarPorId(int id) => _repo.BuscarPorId(id);
        
        //public Task Remover(bool Active) => _repo.Remover(bool Active);

        async Task<Cliente> IClienteService.Criar(Cliente cliente)
        {
            await _repo.Criar(cliente);
            return cliente;
        }

        async Task<Cliente> IClienteService.Atualizar(Cliente cliente)
        {
            await _repo.Atualizar(cliente);
            return cliente;
        }


        public async Task Remover(int id)
        {
            await _repo.Remover(id);
        }

        //async Task<Cliente> IClienteService.Remover(int id)
        //{
        //   var sucesso = await _repo.Remover(id);
        //    if (!sucesso)        
        //        return NotFound("Cliente não encontrado");

        //    return NoContent();
        //}

        //public Task Atualizar(Cliente cliente) => _repo.Atualizar(cliente);
        //public Task Criar(Cliente cliente) => _repo.Criar(cliente);
    }
}
