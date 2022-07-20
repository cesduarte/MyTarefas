using MyTarefas.Domain;

namespace MyTarefas.Application.Contratos
{
    public interface IDepartamentoService
    {
        Task<Departamento> AddDepartamento(int departamentoId, Departamento model);        
        Task<Departamento> UpdateDepartamento(int departamentoId, Departamento model);
        Task<bool> DeleteDepartamento(int departamentoId);
        Task<Departamento[]> GetAllByCardIdAsync(int cardId); 
    }
}