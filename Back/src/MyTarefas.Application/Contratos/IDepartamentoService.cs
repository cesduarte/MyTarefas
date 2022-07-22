

using MyTarefas.Application.Dtos;

namespace MyTarefas.Application.Contratos
{
    public interface IDepartamentoService
    {
        Task<DepartamentoDto> AddDepartamento(long departamentoId, DepartamentoDto model);        
        Task<DepartamentoDto> UpdateDepartamento(long departamentoId, DepartamentoDto model);
        Task<bool> DeleteDepartamento(long departamentoId);
        Task<DepartamentoDto[]> GetAllByCardIdAsync(long cardId);        
    }
}