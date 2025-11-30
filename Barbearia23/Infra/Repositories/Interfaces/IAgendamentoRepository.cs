using Barbearia23.Domain;

namespace Barbearia23.Infra.Repositories.Interfaces
{
    public interface IAgendamentoRepository
    {
        Task<IEnumerable<Agendamento>> BuscarAgendamentos();
        Task<Agendamento?> BuscarPorId(int id);
        Task Criar(Agendamento agendamento);
        Task Atualizar(Agendamento agendamento);
        Task Remover(int id);
    }
}
