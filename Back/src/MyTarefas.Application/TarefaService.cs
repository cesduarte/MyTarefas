using MyTarefas.Application.Contratos;
using MyTarefas.Domain;
using MyTarefas.Persistence.Contrato;

namespace MyTarefas.Application
{
    public class TarefaService: ITarefaService
    {
        private readonly IGeralPersist _geralPersist;

        private readonly ITarefaPersist _tarefaPersist;

        public TarefaService(ITarefaPersist tarefaPersist, IGeralPersist geralPersist)
        {
            _tarefaPersist = tarefaPersist;
            _geralPersist = geralPersist;
        }

        public Task<Tarefa> AddTarefa(int tarefaId, Tarefa model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTarefa(int tarefaId)
        {
            throw new NotImplementedException();
        }

        public Task<Tarefa[]> GetAllTarefasAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Tarefa> UpdateTarefa(int tarefaId, Tarefa model)
        {
            throw new NotImplementedException();
        }
    }
}