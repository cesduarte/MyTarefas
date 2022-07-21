using MyTarefas.Domain;

namespace MyTarefas.Persistence.Contrato
{
    public interface IAcompanhamentoPersist
    {
         Task<Acompanhamento[]> GetAllByCardIdAsync(long cardId); 

         Task<Acompanhamento> GetAcompanhamentoByIdAsync(long acompanhamentoId); 

    }
}