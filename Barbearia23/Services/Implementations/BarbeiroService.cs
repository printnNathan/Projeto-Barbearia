using Barbearia23.Domain;
using Barbearia23.Infra.Repositories.Interfaces;
using Barbearia23.Services.Interfaces;

namespace Barbearia23.Services.Implementations
{
    public class BarbeiroService : IBarbeiroService
    {
        private readonly IBarbeiroRepository _repo;

        public BarbeiroService(IBarbeiroRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Barbeiro>> ListarBarbeiros()
        {
            return await _repo.BuscarBarbeiro();
        }
        public Task<Barbeiro?> BuscarPorId(int id) => _repo.BuscarPorId(id);

        //public Task Remover(bool Active) => _repo.Remover(bool Active);

        async Task<Barbeiro> IBarbeiroService.Criar(Barbeiro barbeiro)
        {
            await _repo.Criar(barbeiro);
            return barbeiro;
        }

        async Task<Barbeiro> IBarbeiroService.Atualizar(Barbeiro barbeiro)
        {
            await _repo.Atualizar(barbeiro);
            return barbeiro;
        }


        public async Task Remover(int id)
        {
            await _repo.Remover(id);
        }
    }
}
