using MyTarefas.Domain;

namespace MyTarefas.Application.Contratos
{
    public interface ITarefaService
    {
        Task<Tarefa> AddTarefa(int tarefaId, Tarefa model);        
        Task<Tarefa> UpdateTarefa(int tarefaId, Tarefa model);
        Task<bool> DeleteTarefa(int tarefaId);
        Task<Tarefa[]> GetAllTarefasAsync();
    }
}