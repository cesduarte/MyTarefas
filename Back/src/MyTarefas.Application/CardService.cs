using MyTarefas.Application.Contratos;
using MyTarefas.Domain;
using MyTarefas.Persistence.Contrato;

namespace MyTarefas.Application
{
    public class CardService : ICardService
    {
        private readonly IGeralPersist _geralPersist;

        private readonly ICardPersist _cardPersist;

        public CardService(ICardPersist cardPersist, IGeralPersist geralPersist)
        {
            _cardPersist = cardPersist;
            _geralPersist = geralPersist;
        }

        public async Task<Card> AddCard(Card model)
        {
            try
            {

                _geralPersist.Add<Card>(model);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var cardRetorno = await _cardPersist.GetByCardIdAsync(model.Id);

                    return cardRetorno;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Card> UpdateCard(int cardId, Card model)
        {
            try
            {
                var card = await _cardPersist.GetByCardIdAsync(cardId);

                if (card == null) return null;

                model.Id = card.Id;

                _geralPersist.Update<Card>(card);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var cardRetorno = await _cardPersist.GetByCardIdAsync(model.Id);

                    return cardRetorno;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteCard(int cardId)
        {
            try
            {
                var card = await _cardPersist.GetByCardIdAsync(cardId);

                if (card == null) throw new Exception("card não encontrado.");

                _geralPersist.Delete<Card>(card);

                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Card[]> GetAllByTarefaIdAsync(int tarefaId)
        {
            var card = await _cardPersist.GetAllByTarefaIdAsync(tarefaId);

            if (card == null) return null;

            return card;
        }

        public async Task<Card[]> GetAllCardsAsync()
        {
            var card = await _cardPersist.GetAllCardsAsync();

            if (card == null) return null;

            return card;
        }
    }
}