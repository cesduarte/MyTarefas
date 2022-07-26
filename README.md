# MyTarefas

Projeto criado para o desafio Key para desenvolvedor

## Instalação
### Back
Clone este repositório, navegue até a pasta **/back/src/MyTarefas.API** e execute o comando **dotnet run**

### Configuração do banco de dados

```csharp
builder.Services.AddDbContext<MyTarefasContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("default"), options =>{
        options.SetPostgresVersion(new Version(<"9.5.2">));        
    })
);
```
```json
"ConnectionStrings": {
    "default": "Server=localhost; Database=mytarefas; Port=5432; User Id=postgres; Password=sup"
  }
```
