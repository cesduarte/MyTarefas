using MyTarefas.Domain;

namespace MyTarefas.Application.Contratos
{
    public interface IDepartamentoService
    {
        Task<Departamento> AddDepartamento(long departamentoId, Departamento model);        
        Task<Departamento> UpdateDepartamento(long departamentoId, Departamento model);
        Task<bool> DeleteDepartamento(long departamentoId);
        Task<Departamento[]> GetAllByCardIdAsync(long cardId);        
    }
}