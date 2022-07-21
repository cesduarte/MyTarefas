using MyTarefas.Domain;

namespace MyTarefas.Persistence.Helpers.Seed
{
    public class SeedAcompanhamentoUsuarios
    {
        public SeedAcompanhamentoUsuarios()
        {
        }

        public List<AcompanhamentoUsuario> CreateList(List<Usuario> usuarios, List<Acompanhamento> acompanhamentos)
        {
            Random randNum = new Random();

            List<AcompanhamentoUsuario> list = new List<AcompanhamentoUsuario>()
            {
                new AcompanhamentoUsuario
                {                   
                    UsuarioId = usuarios[0].Id,
                    AcompanhamentoId = acompanhamentos[0].Id                   
                },

            };

            return list;
        }
    }
}