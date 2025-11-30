using Barbearia23.Domain;

namespace Barbearia23.Services.Interfaces
{
    public interface IBarbeiroService
    {
        Task<Barbeiro> Atualizar(Barbeiro barbeiro);
        Task<Barbeiro?> BuscarPorId(int Id);
        Task<Barbeiro> Criar(Barbeiro barbeiro);
        Task<IEnumerable<Barbeiro>> ListarBarbeiros();
        Task Remover(int id);
    }
}
