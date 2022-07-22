using MyTarefas.Application.Dtos;

namespace MyTarefas.Application.Contratos
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> AddUsuario(long userId, UsuarioDto model);        
        Task<UsuarioDto> UpdateUsuario(long userId, UsuarioDto model);
        Task<bool> DeleteUsuario(long userId);
        Task<UsuarioDto[]> GetAllByAcompanhamentoIdAsync(long acompanhamentoId);

    }
}