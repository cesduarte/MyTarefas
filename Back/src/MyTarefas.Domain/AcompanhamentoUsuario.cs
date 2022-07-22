using System.ComponentModel.DataAnnotations.Schema;

namespace MyTarefas.Domain
{
    public class AcompanhamentoUsuario
    {
        public long UsuarioId { get; set; }        
        public Usuario Usuario { get; set; }
        public long AcompanhamentoId { get; set; }        
        public Acompanhamento Acompanhamento { get; set; }
    }
}