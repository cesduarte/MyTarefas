using Microsoft.EntityFrameworkCore;
using MyTarefas.Domain;
using System;

namespace MyTarefas.Persistence.Helpers.Seed
{
    public class SeedTarefa
    {
        public SeedTarefa()
        {
        }

        public List<Tarefa> CreateList()
        {  
            Random randNum = new Random();
            
            List<Tarefa> list = new List<Tarefa>()
            {
                new Tarefa
                {
                    Id =  randNum.Next(),
                    Descricao = "Aguardando",                    
                },
                new Tarefa
                {
                    Id =  randNum.Next(),
                    Descricao = "Em Andamento",
                },
                new Tarefa
                {
                    Id =  randNum.Next(),
                    Descricao = "Pendência"

                },
                new Tarefa
                {
                    Id =  randNum.Next(),
                    Descricao = "Finalizado"
                },
                new Tarefa
                {
                    Id =  randNum.Next(),
                    Descricao = "Outros"
                }
            };

            return list;
        }

    }
}