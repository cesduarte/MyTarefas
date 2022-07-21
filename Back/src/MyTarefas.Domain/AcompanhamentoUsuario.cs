namespace MyTarefas.Domain
{
    public class AcompanhamentoUsuario
    {
        public long UsuarioId { get; set; }
        public IEnumerable<Usuario>? Usuarios { get; set; }
        public long AcompanhamentoId { get; set; }
        public IEnumerable<Acompanhamento>? Acompanhamentos { get; set; }
    }
}