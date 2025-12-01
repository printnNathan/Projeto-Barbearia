using Barbearia23.Domain;
using Barbearia23.Infra.Context;
using Barbearia23.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Barbearia23.Infra.Repositories
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly BarbeariaContext _context;

        public AgendamentoRepository(BarbeariaContext context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<Agendamento>> BuscarAgendamentos()
        //{
        //    return await _context.Agendamento.ToListAsync();
        //}

        public async Task<IEnumerable<Agendamento>> BuscarAgendamentos()
        {
            return await _context.Agendamento
                                .Include(a => a.Cliente)
                                .Include(a => a.Servico)
                                .Include(a => a.Barbeiro)
                                .ToListAsync();
        }

        public async Task Criar(Agendamento agendamento)
        {
            _context.Agendamento.Add(agendamento);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Agendamento agendamento)
        {
            _context.Agendamento.Update(agendamento);
            await _context.SaveChangesAsync();
        }

        public async Task<Agendamento?> BuscarPorId(int id)
        {
            return await _context.Agendamento.FindAsync(id);
        }

        public async Task Remover(int id)
        {
            var agendamento = await _context.Agendamento.FindAsync(id);

            if (agendamento == null)
                return;

            agendamento.Ativo = false;

            _context.Agendamento.Update(agendamento);
            await _context.SaveChangesAsync();
        }
    }
}
