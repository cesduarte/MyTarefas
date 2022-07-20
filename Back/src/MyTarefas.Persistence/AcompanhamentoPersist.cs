using Microsoft.EntityFrameworkCore;
using MyTarefas.Domain;
using MyTarefas.Persistence.Contextos;
using MyTarefas.Persistence.Contrato;

namespace MyTarefas.Persistence
{
    public class AcompanhamentoPersist : IAcompanhamentoPersist
    {
        private readonly MyTarefasContext _context;

        public AcompanhamentoPersist(MyTarefasContext context)
        {
            _context = context;
        }

        public async Task<Acompanhamento> GetAcompanhamentoByIdAsync(int cardId, int acompanhamentoId)
        {
            IQueryable<Acompanhamento> query = _context.Acompanhamentos;

            query = query.AsNoTracking()
                         .Where(ac => ac.CardId == cardId && ac.Id == acompanhamentoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Acompanhamento[]> GetAllByCardIdAsync(int cardId)
        {
            IQueryable<Acompanhamento> query = _context.Acompanhamentos;

            query = query.AsNoTracking()
                         .Where(ac => ac.CardId == cardId);

            return await query.ToArrayAsync();
        }
    }
}