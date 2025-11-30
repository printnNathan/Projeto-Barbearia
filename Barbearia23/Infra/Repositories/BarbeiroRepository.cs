using Barbearia23.Infra.Repositories.Interfaces;
using Barbearia23.Domain;
using Barbearia23.Infra.Context;
using Microsoft.EntityFrameworkCore;


namespace Barbearia23.Infra.Repositories
{
    public class BarbeiroRepository : IBarbeiroRepository
    {
           private readonly BarbeariaContext _context;

        public BarbeiroRepository(BarbeariaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Barbeiro>> BuscarBarbeiro()
        {
            return await _context.Barbeiro.ToListAsync();
        }

        public async Task Criar(Barbeiro barbeiro)
        {
            _context.Barbeiro.Add(barbeiro);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Barbeiro barbeiro)
        {
            _context.Barbeiro.Update(barbeiro);
            await _context.SaveChangesAsync();
        }

        public async Task<Barbeiro?> BuscarPorId(int id)
        {
            return await _context.Barbeiro.FindAsync(id);
        }

        public async Task Remover(int id)
        {
            var barbeiro = await _context.Barbeiro.FindAsync(id);

            if (barbeiro == null)
                return;

            barbeiro.Ativo = false;

            _context.Barbeiro.Update(barbeiro);
            await _context.SaveChangesAsync();
        }
    }
}
