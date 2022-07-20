using MyTarefas.Domain;

namespace MyTarefas.Persistence.Contrato
{
    public interface IDepartamentoPersist
    {
        Task<Departamento[]> GetAllByCardIdAsync(int cardId); 
    }
}