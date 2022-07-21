using MyTarefas.Domain;

namespace MyTarefas.Persistence.Helpers.Seed
{
    public class SeedUsuario
    {
        public SeedUsuario()
        {
        }

        public List<Usuario> CreateList()
        {
            Random randNum = new Random();

            List<Usuario> list = new List<Usuario>()
            {
                new Usuario
                {
                    Id = randNum.Next(),
                    Descricao = "Carlos",                 
                },

            };

            return list;
        }
    }
}