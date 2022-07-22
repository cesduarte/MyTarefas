using MyTarefas.Application.Dtos;
namespace MyTarefas.Application.Contratos
{
    public interface IAcompanhamentoService
    {
        Task<AcompanhamentoDto> AddAcompanhamento(long cardId, AcompanhamentoDto model);        
        Task<AcompanhamentoDto> UpdateAcompanhamento(long acompanhamentoId, AcompanhamentoDto model);
        Task<bool> DeleteAcompanhamento(long acompanhamentoId);
    }
}