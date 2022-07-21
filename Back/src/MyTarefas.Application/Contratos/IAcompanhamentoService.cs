using MyTarefas.Domain;

namespace MyTarefas.Application.Contratos
{
    public interface IAcompanhamentoService
    {
        Task<Acompanhamento> AddAcompanhamento(long cardId, Acompanhamento model);        
        Task<Acompanhamento> UpdateAcompanhamento(long acompanhamentoId, Acompanhamento model);
        Task<bool> DeleteAcompanhamento(long acompanhamentoId);
    }
}