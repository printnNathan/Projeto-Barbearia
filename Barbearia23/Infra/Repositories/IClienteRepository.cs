using Barbearia23.Domain;

namespace Barbearia23.Infra.Repositories
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetClientes();
        Task<Cliente?> BuscarPorId(int id);
        Task Criar(Cliente cliente);
        Task Atualizar(Cliente cliente);
        Task Remover(int id);
    }
}
