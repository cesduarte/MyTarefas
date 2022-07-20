using MyTarefas.Application.Contratos;
using MyTarefas.Domain;
using MyTarefas.Persistence.Contrato;

namespace MyTarefas.Application
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGeralPersist _geralPersist;

        private readonly IUsuarioPersist _usuarioPersist;

        public UsuarioService(IUsuarioPersist usuarioPersist, IGeralPersist geralPersist)
        {
            _usuarioPersist = usuarioPersist;
            _geralPersist = geralPersist;
        }
        public Task<Usuario> AddUsuario(int userId, Usuario model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUsuario(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario[]> GetAllByAcompanhamentoIdAsync(int acompanhamentoId)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> UpdateUsuario(int userId, Usuario model)
        {
            throw new NotImplementedException();
        }
    }
}