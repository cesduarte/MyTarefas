using MyTarefas.Domain;

namespace MyTarefas.Application.Contratos
{
    public interface IUsuarioService
    {
        Task<Usuario> AddUsuario(int userId, Usuario model);        
        Task<Usuario> UpdateUsuario(int userId, Usuario model);
        Task<bool> DeleteUsuario(int userId);
        Task<Usuario[]> GetAllByAcompanhamentoIdAsync(int acompanhamentoId);

    }
}