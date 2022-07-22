using MyTarefas.Domain.Enum;

namespace MyTarefas.Application.Dtos
{
    public class AcompanhamentoDto
    {
        public long Id { get; set; }        
        public string? HorasPrevistas { get; set; }
        public string? Saldo { get; set; }
        public Status Status { get; set; }
        public IEnumerable<UsuarioDto> Usuarios  { get; set; }        
    }
}