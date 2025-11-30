using Barbearia23.Domain;

namespace Barbearia23.Infra.Repositories.Interfaces
{
    public interface IBarbeiroRepository
    {
        Task<IEnumerable<Barbeiro>> BuscarBarbeiro();
        Task<Barbeiro?> BuscarPorId(int id);
        Task Criar(Barbeiro barbeiro);
        Task Atualizar(Barbeiro barbeiro);
        Task Remover(int id);
    }
}
