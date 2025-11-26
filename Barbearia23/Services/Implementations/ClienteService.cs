using Barbearia23.Domain;
using Barbearia23.Infra.Repositories;
using Barbearia23.Services.Interfaces;

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
            return await _repo.GetClientes();
        }
        public Task<Cliente?> BuscarPorId(int id) => _repo.BuscarPorId(id);
        public Task Criar(Cliente cliente) => _repo.Criar(cliente);
        public Task Atualizar(Cliente cliente) => _repo.Atualizar(cliente);
        public Task Remover(int id) => _repo.Remover(id);


        //public async Task<Cliente?> BuscarPorId(int id)
        //{
        //    //return await BuscarPorId(id) => _repo.BuscarPorId(id);
        //    return await _repo.BuscarPorId(id);
        //}
    }
}
