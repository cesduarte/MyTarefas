using MyTarefas.Domain;

namespace MyTarefas.Application.Contratos
{
    public interface ITarefaService
    {
        Task<Tarefa> AddTarefa(Tarefa model);        
        Task<Tarefa> UpdateTarefa(long tarefaId, Tarefa model);
        Task<bool> DeleteTarefa(long tarefaId);
        Task<Tarefa[]> GetAllTarefasAsync();
    }
}