

using MyTarefas.Application.Dtos;

namespace MyTarefas.Application.Contratos
{
    public interface ICardService
    {
        Task<CardDto> AddCard(CardDto model);        
        Task<CardDto> UpdateCard(long cardId, CardDto model);
        Task<bool> DeleteCard(long cardId);

        Task<CardDto[]> GetAllCardsAsync(); 

        Task<CardDto[]> GetAllByTarefaIdAsync(long tarefaId); 
    }
}