using MyTarefas.Application.Dtos;

namespace MyTarefas.Application.Contratos
{
    public interface ITarefaService
    {
        Task<TarefaDto> AddTarefa(TarefaDto model);        
        Task<TarefaDto> UpdateTarefa(long tarefaId, TarefaDto model);
        Task<bool> DeleteTarefa(long tarefaId);
        Task<TarefaDto[]> GetAllTarefasAsync();
    }
}