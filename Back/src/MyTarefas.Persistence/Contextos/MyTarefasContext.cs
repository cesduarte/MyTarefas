using Microsoft.EntityFrameworkCore;
using MyTarefas.Domain;
using MyTarefas.Persistence.Helpers.Seed;

namespace MyTarefas.Persistence.Contextos
{
    public class MyTarefasContext : DbContext
    {
        public MyTarefasContext(DbContextOptions<MyTarefasContext> options) : base(options) { }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Acompanhamento> Acompanhamentos { get; set; }

        public DbSet<AcompanhamentoUsuario> AcompanhamentoUsuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AcompanhamentoUsuario>()
                .HasKey(AC => new {AC.AcompanhamentoId, AC.UsuarioId});

             modelBuilder.Entity<Tarefa>()
                .HasMany(e => e.Cards)
                .WithOne(rs => rs.Tarefa)
                .HasForeignKey(ee => ee.TarefaId);

            new Seed(modelBuilder).Run();
        }
    }
}