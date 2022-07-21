using System.Collections.Generic;

namespace MyTarefas.Domain
{
    public class Tarefa
    {
        public long Id { get; set; }
        public string? Descricao { get; set; }
        public IEnumerable<Card> Cards{ get; set; }
    }
}