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
                    Descricao = "Usar a branch master, fazer pull, após isso..."
                },
                new Card
                {
                    TarefaId = tarefas.Last().Id,
                    Id = randNum.Next(),
                    Titulo = "Listagem de clientes",
                    Projeto = "Company",
                    Descricao = "Colunas utilizadas: Código, nome, Descrição..."
                },


            };

            return list;
        }
    }
}