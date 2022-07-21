using Microsoft.AspNetCore.Mvc;
using MyTarefas.Application.Contratos;
using MyTarefas.Domain;

namespace MyTarefas.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TarefaController : ControllerBase
{
    private readonly ITarefaService _tarefaService;

    public TarefaController(ITarefaService tarefaService)
    {
        _tarefaService = tarefaService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var tarefas = await _tarefaService.GetAllTarefasAsync();

            if (tarefas == null) return NoContent();

            return Ok(tarefas);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar as tarefas. Erro: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Tarefa model)
    {
        try
        {
            var tarefa = await _tarefaService.AddTarefa(model);
            if (tarefa == null) return NoContent();

            return Ok(tarefa);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar adicionar a tarefa. Erro: {ex.Message}");
        }
    }

}
