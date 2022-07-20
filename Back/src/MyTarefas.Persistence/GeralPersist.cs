using MyTarefas.Persistence.Contextos;
using MyTarefas.Persistence.Contrato;

namespace MyTarefas.Persistence
{
    public class GeralPersist : IGeralPersist
    {
        private readonly MyTarefasContext _context;

        public GeralPersist(MyTarefasContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.AddAsync(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entity) where T : class
        {
            _context.RemoveRange(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0 ;
        }

        public void Update<T>(T entity) where T : class
        {
             _context.Update(entity);
        }
    }
}