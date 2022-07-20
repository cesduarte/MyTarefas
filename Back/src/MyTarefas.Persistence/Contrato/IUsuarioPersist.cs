using MyTarefas.Domain;

namespace MyTarefas.Persistence.Contrato
{
    public interface IUsuarioPersist
    {
       Task<Usuario[]> GetAllByAcompanhamentoIdAsync(int acompanhamentoId); 

       Task<Usuario> GetByUsuarioIdAsync(int acompanhamentoId); 

    }
}