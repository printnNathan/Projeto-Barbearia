using Barbearia23.Domain;

namespace Barbearia23.Services.Interfaces
{
    public interface IClienteService
    {
        Task<Cliente> Atualizar(Cliente cliente);
        Task<Cliente?> BuscarPorId(int Id);
        Task<Cliente> Criar(Cliente cliente);
        Task<IEnumerable<Cliente>> ListarClientes();
        Task Remover(int id);
    }
}
