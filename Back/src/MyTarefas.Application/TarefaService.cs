using MyTarefas.Application.Contratos;
using MyTarefas.Domain;
using MyTarefas.Persistence.Contrato;

namespace MyTarefas.Application
{
    public class TarefaService : ITarefaService
    {
        private readonly IGeralPersist _geralPersist;

        private readonly ITarefaPersist _tarefaPersist;

        public TarefaService(ITarefaPersist tarefaPersist, IGeralPersist geralPersist)
        {
            _tarefaPersist = tarefaPersist;
            _geralPersist = geralPersist;
        }

        public async Task<Tarefa> AddTarefa(Tarefa model)
        {
            try
            {

                _geralPersist.Add<Tarefa>(model);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var TarefaRetorno = await _tarefaPersist.GetByTarefaIdAsync(model.Id);

                    return TarefaRetorno;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Tarefa> UpdateTarefa(long tarefaId, Tarefa model)
        {
            try
            {
                var tarefa = await _tarefaPersist.GetByTarefaIdAsync(tarefaId);

                if (tarefa == null) return null;

                model.Id = tarefa.Id;

                _geralPersist.Update<Tarefa>(tarefa);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var tarefaRetorno = await _tarefaPersist.GetByTarefaIdAsync(model.Id);

                    return tarefaRetorno;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteTarefa(long tarefaId)
        {
            try
            {
                var tarefa = await _tarefaPersist.GetByTarefaIdAsync(tarefaId);

                if (tarefa == null) throw new Exception("Tarefa não encontrado.");

                _geralPersist.Delete<Tarefa>(tarefa);

                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Tarefa[]> GetAllTarefasAsync()
        {
            var tarefa = await _tarefaPersist.GetAllTarefasAsync();

            if (tarefa == null) return null;

            return tarefa;
        }

    }
}