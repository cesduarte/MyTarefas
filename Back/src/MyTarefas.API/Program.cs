using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using MyTarefas.Application;
using MyTarefas.Application.Contratos;
using MyTarefas.Persistence;
using MyTarefas.Persistence.Contextos;
using MyTarefas.Persistence.Contrato;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MyTarefasContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("default"), options =>{
        options.SetPostgresVersion(new Version("9.5.2"));
    })
);

builder.Services.AddControllers()
  .AddJsonOptions(options =>
                        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
                    )
                    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling =
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAcompanhamentoService, AcompanhamentoService>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();
builder.Services.AddScoped<ITarefaService, TarefaService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddScoped<IAcompanhamentoPersist, AcompanhamentoPersist>();
builder.Services.AddScoped<ICardPersist, CardPersist>();
builder.Services.AddScoped<IDepartamentoPersist, DepartamentoPersist>();
builder.Services.AddScoped<ITarefaPersist, TarefaPersist>();
builder.Services.AddScoped<IUsuarioPersist, UsuarioPersist>();
builder.Services.AddScoped<IGeralPersist, GeralPersist>();

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
   var services = serviceScope.ServiceProvider;
    
   var dbcontext = services.GetRequiredService<MyTarefasContext>();   

   dbcontext.Database.Migrate();
}
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
