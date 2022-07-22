using AutoMapper;
using MyTarefas.Application.Contratos;
using MyTarefas.Application.Dtos;
using MyTarefas.Domain;
using MyTarefas.Persistence.Contrato;

namespace MyTarefas.Application
{
    public class AcompanhamentoService : IAcompanhamentoService
    {
        private readonly IGeralPersist _geralPersist;

        private readonly IAcompanhamentoPersist _acompanhamentoPersist;

        private readonly IMapper _mapper;

        public AcompanhamentoService(IAcompanhamentoPersist acompanhamentoPersist, IGeralPersist geralPersist, IMapper mapper)
        {
            _acompanhamentoPersist = acompanhamentoPersist;
            _geralPersist = geralPersist;
             _mapper = mapper;
        }

        public async Task<AcompanhamentoDto?> AddAcompanhamento(long cardId, AcompanhamentoDto model)
        {
            try
            {
                var acompanhamento = _mapper.Map<Acompanhamento>(model);
                acompanhamento.CardId = cardId;              

                _geralPersist.Add<Acompanhamento>(acompanhamento);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var acompanhamentoRetorno = await _acompanhamentoPersist.GetAcompanhamentoByIdAsync(model.Id);

                    return _mapper.Map<AcompanhamentoDto>(acompanhamento);                    
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAcompanhamento(long acompanhamentoId)
        {

            try
            {
                var acompanhamento = await _acompanhamentoPersist.GetAcompanhamentoByIdAsync(acompanhamentoId);

                if (acompanhamento == null) throw new Exception("Acompanhamento não encontrado.");

                _geralPersist.Delete<Acompanhamento>(acompanhamento);

                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AcompanhamentoDto?> UpdateAcompanhamento(long acompanhamentoId, AcompanhamentoDto model)
        {
            try
            {
                var acompanhamento = await _acompanhamentoPersist.GetAcompanhamentoByIdAsync(acompanhamentoId);

                if (acompanhamento == null) return null;

                model.Id = acompanhamento.Id;

                _mapper.Map(model, acompanhamento);                

                _geralPersist.Update<Acompanhamento>(acompanhamento);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var acompanhamentoRetorno = await _acompanhamentoPersist.GetAcompanhamentoByIdAsync(model.Id);

                    return _mapper.Map<AcompanhamentoDto>(acompanhamento);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
    }
}