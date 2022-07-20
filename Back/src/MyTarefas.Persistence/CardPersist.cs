using Microsoft.EntityFrameworkCore;
using MyTarefas.Domain;
using MyTarefas.Persistence.Contextos;
using MyTarefas.Persistence.Contrato;

namespace MyTarefas.Persistence
{
    public class CardPersist : ICardPersist
    {
        private readonly MyTarefasContext _context;

        public CardPersist(MyTarefasContext context)
        {
            _context = context;
        }
        public async Task<Card[]> GetAllByTarefaIdAsync(int tarefaId)
        {
             IQueryable<Card> query = _context.Cards
                .Include(d => d.Departamento)
                .Include(ac => ac.Acompanhamento);

            query = query.AsNoTracking().Where(c => c.Id == tarefaId);                         

            return await query.ToArrayAsync();
        }

        public async Task<Card[]> GetAllCardsAsync()
        {
            IQueryable<Card> query = _context.Cards
                .Include(d => d.Departamento)
                .Include(ac => ac.Acompanhamento);

            query = query.AsNoTracking();                         

            return await query.ToArrayAsync();
        }
    }
}