using Barbearia23.Domain;

namespace Barbearia23.Services.Interfaces
{
    public interface IClienteService
    {

        Task<Cliente?> BuscarPorId(int Id);
        Task<IEnumerable<Cliente>> ListarClientes();
    }
}
