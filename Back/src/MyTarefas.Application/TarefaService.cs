using AutoMapper;
using MyTarefas.Application.Contratos;
using MyTarefas.Application.Dtos;
using MyTarefas.Domain;
using MyTarefas.Persistence.Contrato;

namespace MyTarefas.Application
{
    public class TarefaService : ITarefaService
    {
        private readonly IGeralPersist _geralPersist;

        private readonly ITarefaPersist _tarefaPersist;

         private readonly IMapper _mapper;

        public TarefaService(ITarefaPersist tarefaPersist, IGeralPersist geralPersist, IMapper mapper)
        {
            _tarefaPersist = tarefaPersist;
            _geralPersist = geralPersist;
             _mapper = mapper;
        }

        public async Task<TarefaDto> AddTarefa(TarefaDto model)
        {
            try
            {
                var tarefa = _mapper.Map<Tarefa>(model);

                _geralPersist.Add<Tarefa>(tarefa);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var tarefaRetorno = await _tarefaPersist.GetByTarefaIdAsync(model.Id);

                    return _mapper.Map<TarefaDto>(tarefaRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<TarefaDto> UpdateTarefa(long tarefaId, TarefaDto model)
        {
            try
            {
                var tarefa = await _tarefaPersist.GetByTarefaIdAsync(tarefaId);

                if (tarefa == null) return null;

                model.Id = tarefa.Id;

                 _mapper.Map(model, tarefa );

                _geralPersist.Update<Tarefa>(tarefa);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var tarefaRetorno = await _tarefaPersist.GetByTarefaIdAsync(model.Id);

                    return _mapper.Map<TarefaDto>(tarefaRetorno);
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

        public async Task<TarefaDto[]> GetAllTarefasAsync()
        {
            var tarefas = await _tarefaPersist.GetAllTarefasAsync();            

            if (tarefas == null) return null;                

            return _mapper.Map<TarefaDto[]>(tarefas);
        }

    }
}