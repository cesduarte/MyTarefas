using Microsoft.EntityFrameworkCore;
using MyTarefas.Persistence.Contextos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MyTarefasContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("default"), options =>{
        options.SetPostgresVersion(new Version("9.5.2"));
    })
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
