using System.Threading.Tasks;
using MyTarefas.Domain;

namespace MyTarefas.Persistence.Contrato
{
    public interface ITarefaPersist
    {
         Task<Tarefa[]> GetAllTarefasAsync();

         Task<Tarefa> GetByTarefaIdAsync(int tarefaId);
    }
}