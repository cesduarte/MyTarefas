using MyTarefas.Domain;

namespace MyTarefas.Application.Contratos
{
    public interface ICardService
    {
        Task<Card> AddCard(int cardId, Card model);        
        Task<Card> UpdateCard(int cardId, Card model);
        Task<bool> DeleteCard(int cardId);

        Task<Card[]> GetAllCardsAsync(); 

        Task<Card[]> GetAllByTarefaIdAsync(int tarefaId); 
    }
}