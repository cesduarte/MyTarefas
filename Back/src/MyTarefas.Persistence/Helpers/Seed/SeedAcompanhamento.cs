using MyTarefas.Domain;

namespace MyTarefas.Persistence.Helpers.Seed
{
    public class SeedAcompanhamento
    {
        public SeedAcompanhamento()
        {
        }
        public List<Acompanhamento> CreateList(List<Card> cads)
        {
            Random randNum = new Random();

            List<Acompanhamento> list = new List<Acompanhamento>()
            {
                new Acompanhamento
                {                   
                    Id = randNum.Next(),
                    Status = Domain.Enum.Status.ATENCAO,
                    HorasPrevistas = "00:30",
                    Saldo = "00:10",
                    CardId = cads[0].Id
                },

            };

            return list;
        }
    }
}