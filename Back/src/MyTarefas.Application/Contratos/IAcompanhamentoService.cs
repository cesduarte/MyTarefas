using MyTarefas.Domain;

namespace MyTarefas.Application.Contratos
{
    public interface IAcompanhamentoService
    {
        Task<Acompanhamento> AddAcompanhamento(int cardId, Acompanhamento model);        
        Task<Acompanhamento> UpdateAcompanhamento(int acompanhamentoId, Acompanhamento model);
        Task<bool> DeleteAcompanhamento(int acompanhamentoId);
    }
}