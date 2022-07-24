using MyTarefas.Domain;

namespace MyTarefas.Persistence.Helpers.Seed
{
    public class SeedCard
    {
        public SeedCard()
        {
        }
        public List<Card> CreateList(List<Tarefa> tarefas)
        {
            Random randNum = new Random();

            List<Card> list = new List<Card>()
            {
                new Card
                {
                    TarefaId = tarefas.First().Id,
                    Id = randNum.Next(),
                    Titulo = "Criar Migration",
                    Projeto = "Company",
                    Descricao = "Usar a branch master, fazer pull, após isso...",
                    posicaoVertical = 1,
                },
                new Card
                {
                    TarefaId = tarefas.First().Id,
                    Id = randNum.Next(),
                    Titulo = "testee",
                    Projeto = "Company",
                    Descricao = "aaaaaaaaa",
                    posicaoVertical = 2,
                },
                new Card
                {
                    TarefaId = tarefas.First().Id,
                    Id = randNum.Next(),
                    Titulo = "bbbbbbbbbb",
                    Projeto = "Company",
                    Descricao = "bbbbbbbbbbbbbb",
                    posicaoVertical = 3,
                },
                 new Card
                {
                    TarefaId = tarefas.First().Id,
                    Id = randNum.Next(),
                    Titulo = "cccccccccc",
                    Projeto = "Company",
                    Descricao = "ccccccccccccc",
                    posicaoVertical = 4,
                },
                new Card
                {
                    TarefaId = tarefas.Last().Id,
                    Id = randNum.Next(),
                    Titulo = "Listagem de clientes",
                    Projeto = "Company",
                    Descricao = "Colunas utilizadas: Código, nome, Descrição...",
                    posicaoVertical = 2,
                },


            };

            return list;
        }
    }
}