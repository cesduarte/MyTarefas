namespace MyTarefas.Application.Dtos
{
    public class TarefaDto
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<CardDto> Cards{ get; set; }
    }
}