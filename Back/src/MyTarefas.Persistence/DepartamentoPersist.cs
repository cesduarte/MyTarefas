using Microsoft.EntityFrameworkCore;
using MyTarefas.Domain;
using MyTarefas.Persistence.Contextos;
using MyTarefas.Persistence.Contrato;

namespace MyTarefas.Persistence
{
    public class DepartamentoPersist : IDepartamentoPersist
    {
        private readonly MyTarefasContext _context;

        public DepartamentoPersist(MyTarefasContext context)
        {
            _context = context;
        }
        public async Task<Departamento[]> GetAllByCardIdAsync(long cardId)
        {
            IQueryable<Departamento> query = _context.Departamentos;

            query = query.AsNoTracking()
                         .Where(c => c.CardId == cardId);

            return await query.ToArrayAsync();
        }

        public async Task<Departamento> GetByDepartamentoIdAsync(long departamentoId)
        {
            IQueryable<Departamento> query = _context.Departamentos;

            query = query.AsNoTracking()
                         .Where(c => c.Id == departamentoId);

            return await query.FirstOrDefaultAsync();
        }
    }
}