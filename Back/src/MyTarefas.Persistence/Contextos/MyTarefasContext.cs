using Microsoft.EntityFrameworkCore;
using MyTarefas.Domain;

namespace MyTarefas.Persistence.Contextos
{
    public class MyTarefasContext : DbContext
    {
        public MyTarefasContext(DbContextOptions<MyTarefasContext> options) : base(options){}

        public DbSet<Tarefa> Tarefas{get; set;}
        public DbSet<Card> Cards{get; set;}
        public DbSet<Departamento> Departamentos{get; set;}
        public DbSet<Usuario> Usuarios{get; set;}
        public DbSet<Acompanhamento> Acompanhamentos{get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);           
        }
    }
}