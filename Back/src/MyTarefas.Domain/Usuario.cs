namespace MyTarefas.Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }

        public int AcompanhamentoId { get; set; }
    }
}