using MyTarefas.Domain.Enum;

namespace MyTarefas.Domain
{
    public class Acompanhamento
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public string? HorasPrevistas { get; set; }
        public string? Saldo { get; set; }
        public Status Status { get; set; }
        public IEnumerable<Usuario>? Usuarios { get; set; }
        public int CardId { get; set; }
    }
}