using MyTarefas.Domain;

namespace MyTarefas.Persistence.Contrato
{
    public interface ICardPersist
    {
        Task<Card[]> GetAllCardsAsync(); 

        Task<Card[]> GetAllByTarefaIdAsync(long tarefaId); 

        Task<Card> GetByCardIdAsync(long cardId);         

    }
}