using Barbearia23.Domain;

namespace Barbearia23.Infra.Repositories.Interfaces
{
    public interface IServicoRepository
    {
        Task<IEnumerable<Servico>> BuscarServicos();
        Task<Servico?> BuscarPorId(int id);
        Task Criar(Servico servico);
        Task Atualizar(Servico servico);
        Task Remover(int id);
    }
}
