using Microsoft.EntityFrameworkCore;
using MyTarefas.Domain;
using MyTarefas.Persistence.Contextos;
using MyTarefas.Persistence.Contrato;

namespace MyTarefas.Persistence
{
    public class UsuarioPersist : IUsuarioPersist
    {
        private readonly MyTarefasContext _context;

        public UsuarioPersist(MyTarefasContext context)
        {
            _context = context;
        }

        public async Task<Usuario[]> GetAllByAcompanhamentoIdAsync(int acompanhamentoId)
        {
              IQueryable<Usuario> query = _context.Usuarios;

            query = query.AsNoTracking()
                         .Where(ac => ac.AcompanhamentoId == acompanhamentoId);

            return await query.ToArrayAsync();
        }

        public Task<Usuario> GetByUsuarioIdAsync(int acompanhamentoId)
        {
            throw new NotImplementedException();
        }
    }
}