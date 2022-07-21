using MyTarefas.Application.Contratos;
using MyTarefas.Domain;
using MyTarefas.Persistence.Contrato;

namespace MyTarefas.Application
{
    public class AcompanhamentoService : IAcompanhamentoService
    {
        private readonly IGeralPersist _geralPersist;

        private readonly IAcompanhamentoPersist _acompanhamentoPersist;

        public AcompanhamentoService(IAcompanhamentoPersist acompanhamentoPersist, IGeralPersist geralPersist)
        {
            _acompanhamentoPersist = acompanhamentoPersist;
            _geralPersist = geralPersist;
        }

        public async Task<Acompanhamento?> AddAcompanhamento(long cardId, Acompanhamento model)
        {
            try
            {
                model.CardId = cardId;

                _geralPersist.Add<Acompanhamento>(model);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var acompanhamentoRetorno = await _acompanhamentoPersist.GetAcompanhamentoByIdAsync(model.Id);

                    return acompanhamentoRetorno;
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

        public async Task<Acompanhamento?> UpdateAcompanhamento(long acompanhamentoId, Acompanhamento model)
        {
            try
            {
                var acompanhamento = await _acompanhamentoPersist.GetAcompanhamentoByIdAsync(acompanhamentoId);

                if (acompanhamento == null) return null;

                model.Id = acompanhamento.Id;                

                _geralPersist.Update<Acompanhamento>(acompanhamento);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var acompanhamentoRetorno = await _acompanhamentoPersist.GetAcompanhamentoByIdAsync(model.Id);

                    return acompanhamentoRetorno;
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