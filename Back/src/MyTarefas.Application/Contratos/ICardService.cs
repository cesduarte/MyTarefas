using MyTarefas.Domain;

namespace MyTarefas.Application.Contratos
{
    public interface ICardService
    {
        Task<Card> AddCard(Card model);        
        Task<Card> UpdateCard(long cardId, Card model);
        Task<bool> DeleteCard(long cardId);

        Task<Card[]> GetAllCardsAsync(); 

        Task<Card[]> GetAllByTarefaIdAsync(long tarefaId); 
    }
}