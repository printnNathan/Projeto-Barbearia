using Barbearia23.Domain;

namespace Barbearia23.Infra.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> BuscarClientes();
        Task<Cliente?> BuscarPorId(int id);
        Task Criar(Cliente cliente);
        Task Atualizar(Cliente cliente);
        Task Remover(int id);
    }
}
