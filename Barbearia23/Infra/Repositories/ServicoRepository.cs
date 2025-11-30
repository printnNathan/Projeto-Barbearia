using Barbearia23.Domain;
using Barbearia23.Infra.Context;
using Barbearia23.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Barbearia23.Infra.Repositories
{
    public class ServicoRepository : IServicoRepository
    {
        private readonly BarbeariaContext _context;

        public ServicoRepository(BarbeariaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Servico>> BuscarServicos()
        {
            return await _context.Servico.ToListAsync();
        }

        //public async Task<Servico> BurcarPorId(int id) 
        //    => await _context.Servicos.FindAsync(id);

        public async Task Criar(Servico servico)
        {
            _context.Servico.Add(servico);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Servico servico)
        {
            _context.Servico.Update(servico);
            await _context.SaveChangesAsync();
        }

        //public async Task Remover(int id)
        //{
        //    var cli = _context.Servicos.FindAsync(id);
        //    if ( cli != null)
        //    {
        //        _context.Servicos.Remove(await cli);
        //        await _context.SaveChangesAsync();
        //    }
        //}

        public async Task<Servico?> BuscarPorId(int id)
        {
            return await _context.Servico.FindAsync(id);
        }

        public async Task Remover(int id)
        {
            var servico = await _context.Servico.FindAsync(id);

            if (servico == null)
                return;

            servico.Ativo = false;

            _context.Servico.Update(servico);
            await _context.SaveChangesAsync();
        }
    }
}