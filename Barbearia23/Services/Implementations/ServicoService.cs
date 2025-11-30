using Barbearia23.Domain;
using Barbearia23.Infra.Repositories.Interfaces;
using Barbearia23.Services.Interfaces;

namespace Barbearia23.Services.Implementations
{
    public class ServicoService : IServicoService
    {
        private readonly IServicoRepository _repo;

        public ServicoService(IServicoRepository repo)
        {
            _repo = repo;
        }


        public async Task<IEnumerable<Servico>> ListarServicos()
        {
            return await _repo.BuscarServicos();
        }
        public Task<Servico?> BuscarPorId(int id) => _repo.BuscarPorId(id);

        //public Task Remover(bool Active) => _repo.Remover(bool Active);

        async Task<Servico> IServicoService.Criar(Servico servico)
        {
            await _repo.Criar(servico);
            return servico;
        }

        async Task<Servico> IServicoService.Atualizar(Servico servico)
        {
            await _repo.Atualizar(servico);
            return servico;
        }


        public async Task Remover(int id)
        {
            await _repo.Remover(id);
        }
    }
}
