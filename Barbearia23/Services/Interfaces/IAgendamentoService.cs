using Barbearia23.Domain;

namespace Barbearia23.Services.Interfaces
{
    public interface IAgendamentoService
    {
        Task<Agendamento> Atualizar(Agendamento agendamento);
        Task<Agendamento?> BuscarPorId(int Id);
        Task<Agendamento> Criar(Agendamento agendamento);
        Task<IEnumerable<Agendamento>> ListarAgendamentos();
        Task Remover(int id);
    }
}
