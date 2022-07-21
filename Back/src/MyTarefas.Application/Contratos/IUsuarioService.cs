using MyTarefas.Domain;

namespace MyTarefas.Application.Contratos
{
    public interface IUsuarioService
    {
        Task<Usuario> AddUsuario(long userId, Usuario model);        
        Task<Usuario> UpdateUsuario(long userId, Usuario model);
        Task<bool> DeleteUsuario(long userId);
        Task<Usuario[]> GetAllByAcompanhamentoIdAsync(long acompanhamentoId);

    }
}