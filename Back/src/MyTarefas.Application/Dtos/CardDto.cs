namespace MyTarefas.Application.Dtos
{
    public class CardDto
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public string Titulo { get; set; }
        public string Projeto { get; set; }
        public int posicaoVertical { get; set; }
        public DateTime DataPrevisao { get; set; }       
        public AcompanhamentoDto Acompanhamento { get; set; }
        public long TarefaId { get; set; }

    }
}