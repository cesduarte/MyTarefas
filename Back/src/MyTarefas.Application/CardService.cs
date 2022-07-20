using MyTarefas.Application.Contratos;
using MyTarefas.Domain;
using MyTarefas.Persistence.Contrato;

namespace MyTarefas.Application
{
    public class CardService: ICardService
    {
        private readonly IGeralPersist _geralPersist;

        private readonly ICardPersist _cardPersist;

        public CardService(ICardPersist cardPersist, IGeralPersist geralPersist)
        {
            _cardPersist = cardPersist;
            _geralPersist = geralPersist;
        }

        public Task<Card> AddCard(int cardId, Card model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCard(int cardId)
        {
            throw new NotImplementedException();
        }

        public Task<Card[]> GetAllByTarefaIdAsync(int tarefaId)
        {
            throw new NotImplementedException();
        }

        public Task<Card[]> GetAllCardsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Card> UpdateCard(int cardId, Card model)
        {
            throw new NotImplementedException();
        }
    }
}