using Microsoft.EntityFrameworkCore;
using MyTarefas.Domain;

namespace MyTarefas.Persistence.Helpers.Seed
{
    public class Seed
    {
        private readonly ModelBuilder modelBuilder;
        private List<Tarefa> tarefas;
        private List<Card> cards;
        private List<Usuario> usuarios;
        private List<Acompanhamento> acompanhamentos;
        private List<AcompanhamentoUsuario> acompanhamentoUsuarios;

        public Seed(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Run()
        {
            CreateList();

            modelBuilder.Entity<Tarefa>().HasData(tarefas);

            modelBuilder.Entity<Card>().HasData(cards);

            modelBuilder.Entity<Usuario>().HasData(usuarios);

            modelBuilder.Entity<Acompanhamento>().HasData(acompanhamentos);

            modelBuilder.Entity<AcompanhamentoUsuario>().HasData(acompanhamentoUsuarios);
        }
        private void CreateList()
        {
            CreateListTarefas();

            CreateListCards();

            CreateListUsuarios();

            CreateListAcompanhamentos();

            CreateListAcompanhamentosUsuarios();
        }
        private void CreateListTarefas() => tarefas = new SeedTarefa().CreateList();

        private void CreateListCards() => cards = new SeedCard().CreateList(tarefas);

        private void CreateListUsuarios() => usuarios = new SeedUsuario().CreateList();

        private void CreateListAcompanhamentos() => acompanhamentos = new SeedAcompanhamento().CreateList(cards);

        private void CreateListAcompanhamentosUsuarios() => acompanhamentoUsuarios = new SeedAcompanhamentoUsuarios().CreateList(usuarios,acompanhamentos);

    }
}