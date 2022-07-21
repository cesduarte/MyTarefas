using MyTarefas.Domain;

namespace MyTarefas.Persistence.Contrato
{
    public interface IUsuarioPersist
    {
       Task<Usuario[]> GetAllByAcompanhamentoIdAsync(long acompanhamentoId); 

       Task<Usuario> GetByUsuarioIdAsync(long acompanhamentoId); 

    }
}