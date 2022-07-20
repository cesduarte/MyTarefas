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

        public async Task<Acompanhamento> AddAcompanhamento(int cardId, Acompanhamento model)
        {
            try
            {
                 model.CardId = cardId;

                _geralPersist.Add<Acompanhamento>(model);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var acompanhamentoRetorno = await _acompanhamentoPersist.GetAcompanhamentoByIdAsync(cardId, model.Id);

                    return acompanhamentoRetorno;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> DeleteAcompanhamento(int acompanhamentoId)
        {
            throw new NotImplementedException();
        }

        public Task<Acompanhamento> UpdateAcompanhamento(int acompanhamentoId, Acompanhamento model)
        {
            throw new NotImplementedException();
        }
    }
}