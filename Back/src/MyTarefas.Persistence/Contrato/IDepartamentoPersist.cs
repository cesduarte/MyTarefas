using MyTarefas.Domain;

namespace MyTarefas.Persistence.Contrato
{
    public interface IDepartamentoPersist
    {
        Task<Departamento[]> GetAllByCardIdAsync(long cardId); 

        Task<Departamento> GetByDepartamentoIdAsync(long departamentoId);  
    }
}