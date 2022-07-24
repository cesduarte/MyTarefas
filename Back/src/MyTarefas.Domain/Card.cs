using System;

namespace MyTarefas.Domain
{
    public class Card
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public string Titulo { get; set; }
        public string Projeto { get; set; }
        public int posicaoVertical { get; set; }
        public DateTime DataPrevisao { get; set; }
        public Departamento Departamento { get; set; }
        public Acompanhamento Acompanhamento { get; set; } 
        public long TarefaId { get; set; }
        public Tarefa Tarefa   { get; set; }


    }
}