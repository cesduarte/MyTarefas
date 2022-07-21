using Microsoft.EntityFrameworkCore;
using MyTarefas.Domain;
using MyTarefas.Persistence.Contextos;
using MyTarefas.Persistence.Contrato;

namespace MyTarefas.Persistence
{
    public class TarefaPersist : ITarefaPersist
    {
        private readonly MyTarefasContext _context;

        public TarefaPersist(MyTarefasContext context)
        {
            _context = context;
        }

        public async Task<Tarefa[]> GetAllTarefasAsync()
        {
            IQueryable<Tarefa> query = _context.Tarefas
            .Include(c => c.Cards);

            query = query.AsNoTracking();                         

            return await query.ToArrayAsync();
        }

        public async Task<Tarefa> GetByTarefaIdAsync(long tarefaId)
        {
             IQueryable<Tarefa> query = _context.Tarefas
            .Include(c => c.Cards);

            query = query.AsNoTracking()
            .Where(t => t.Id == tarefaId);                         

            return await query.FirstOrDefaultAsync();
        }
    }
}