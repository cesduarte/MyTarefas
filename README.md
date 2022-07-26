# MyTarefas

Projeto criado para o desafio Key para desenvolvedor

## Instalação

### Configuração do banco de dados
Definir a versão do banco **Back\src\MyTarefas.API\Program.cs**

```csharp
builder.Services.AddDbContext<MyTarefasContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("default"), options =>{
        options.SetPostgresVersion(new Version(<"9.5.2">));        
    })
);
```
Inserir as credenciais de acesso **Back\src\MyTarefas.API\appsettings.json**
```json
"ConnectionStrings": {
    "default": "Server=localhost; Database=mytarefas; Port=5432; User Id=postgres; Password=sup"
  }
```
### Back
Clone este repositório, navegue até a pasta **/back/src/MyTarefas.API** e execute o comando **dotnet run**

### Tecnologias Utilizadas
Framework utilizados: O Framework utilizado foi .Net 6.0

ORM utilizado: Entityframework;

Documentação: Swagger;

Outros Libs: AutoMapper para mapear os objetos do Domain para os DTOs;

Arquitetura e padroes de projeto:Inicialmente foi utilizado o DDD para facilitar o reúso dos elementos, também na camada de API utilizado o MVC para facilitar a manutenção;

