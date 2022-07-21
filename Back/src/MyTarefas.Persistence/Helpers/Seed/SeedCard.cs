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
                    TarefaId = tarefas[1].Id,
                    Id = randNum.Next(),
                    Titulo = "Criar Migration",
                    Projeto = "Company",
                    Descricao = "Usar a branch master, fazer pull, após isso..."
                },

            };

            return list;
        }
    }
}