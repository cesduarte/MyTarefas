using MyTarefas.Domain;

namespace MyTarefas.Persistence.Contrato
{
    public interface IAcompanhamentoPersist
    {
         Task<Acompanhamento[]> GetAllByCardIdAsync(int cardId); 

         Task<Acompanhamento> GetAcompanhamentoByIdAsync(int cardId, int acompanhamentoId); 

    }
}