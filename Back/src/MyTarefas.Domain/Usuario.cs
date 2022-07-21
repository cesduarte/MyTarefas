namespace MyTarefas.Domain
{
    public class Usuario
    {
        public long Id { get; set; }
        public string? Descricao { get; set; }
        public IEnumerable<AcompanhamentoUsuario>? AcompanhamentosUsuarios { get; set; }
    }
}