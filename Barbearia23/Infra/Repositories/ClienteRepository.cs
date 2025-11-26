using Barbearia23.Domain;
using Barbearia23.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Barbearia23.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly BarbeariaContext _context;

        public ClienteRepository(BarbeariaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        //public async Task<Cliente> BurcarPorId(int id) 
        //    => await _context.Clientes.FindAsync(id);

        public async Task Criar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Cliente cliente)
        {
            _context.Clientes.Update(cliente); 
            await _context.SaveChangesAsync(); 
        }

        public async Task Remover(int id)
        {
            var cli = _context.Clientes.FindAsync(id);
            if ( cli != null)
            {
                _context.Clientes.Remove(await cli);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Cliente?> BuscarPorId(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }
    }
}
