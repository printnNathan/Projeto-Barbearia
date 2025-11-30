using Barbearia23.Domain;
using Barbearia23.Infra.Repositories.Interfaces;
using Barbearia23.Services.Interfaces;

namespace Barbearia23.Services.Implementations
{
    public class AgendamentoService : IAgendamentoService
    {
        private readonly IAgendamentoRepository _repo;

        public AgendamentoService(IAgendamentoRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Agendamento>> ListarAgendamentos()
        {
            return await _repo.BuscarAgendamentos();
        }
        public Task<Agendamento?> BuscarPorId(int id) => _repo.BuscarPorId(id);

        //public Task Remover(bool Active) => _repo.Remover(bool Active);

        async Task<Agendamento> IAgendamentoService.Criar(Agendamento agendamento)
        {
            await _repo.Criar(agendamento);
            return agendamento;
        }

        async Task<Agendamento> IAgendamentoService.Atualizar(Agendamento agendamento)
        {
            await _repo.Atualizar(agendamento);
            return agendamento;
        }


        public async Task Remover(int id)
        {
            await _repo.Remover(id);
        }
    }
}
