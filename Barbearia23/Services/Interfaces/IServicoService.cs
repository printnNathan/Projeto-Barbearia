using Barbearia23.Domain;

namespace Barbearia23.Services.Interfaces
{
    public interface IServicoService
    {
        Task<Servico> Atualizar(Servico servico);
        Task<Servico?> BuscarPorId(int Id);
        Task<Servico> Criar(Servico servico);
        Task<IEnumerable<Servico>> ListarServicos();
        Task Remover(int id);
    }
}
