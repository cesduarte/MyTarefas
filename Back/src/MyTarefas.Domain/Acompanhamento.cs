using MyTarefas.Domain.Enum;

namespace MyTarefas.Domain
{
    public class Acompanhamento
    {
        public long Id { get; set; }        
        public string HorasPrevistas { get; set; }
        public string Saldo { get; set; }
        public Status Status { get; set; }
        public IEnumerable<AcompanhamentoUsuario> AcompanhamentosUsuarios  { get; set; }
        public long CardId { get; set; }
    }
}