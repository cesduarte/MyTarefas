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
        public async Task<Usuario> AddUsuario(long userId, Usuario model)
        {
             try
            {

                _geralPersist.Add<Usuario>(model);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var usuarioRetorno = await _usuarioPersist.GetByUsuarioIdAsync(model.Id);

                    return usuarioRetorno;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Usuario> UpdateUsuario(long userId, Usuario model)
        {
           try
            {
                var usuario = await _usuarioPersist.GetByUsuarioIdAsync(userId);

                if (usuario == null) return null;

                model.Id = usuario.Id;

                _geralPersist.Update<Usuario>(usuario);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var usuarioRetorno = await _usuarioPersist.GetByUsuarioIdAsync(model.Id);

                    return usuarioRetorno;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteUsuario(long userId)
        {
            try
            {
                var usuario = await _usuarioPersist.GetByUsuarioIdAsync(userId);

                if (usuario == null) throw new Exception("usuario não encontrado.");

                _geralPersist.Delete<Usuario>(usuario);

                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Usuario[]> GetAllByAcompanhamentoIdAsync(long acompanhamentoId)
        {
             var usuario  = await _usuarioPersist.GetAllByAcompanhamentoIdAsync(acompanhamentoId);

            if ( usuario == null) return null;

            return usuario;
        }        
    }
}