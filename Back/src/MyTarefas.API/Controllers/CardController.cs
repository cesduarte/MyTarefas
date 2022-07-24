using Microsoft.AspNetCore.Mvc;
using MyTarefas.Application.Contratos;
using MyTarefas.Application.Dtos;


namespace MyTarefas.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CardController : ControllerBase
{
    private readonly ICardService _cardService;

    public CardController(ICardService CardService)
    {
        _cardService = CardService;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var cards = await _cardService.GetAllCardsAsync();

            if (cards == null) return NoContent();

            return Ok(cards);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar os Cards. Erro: {ex.Message}");
        }
    }   

     [HttpPost("{tarefaid}")]
    public async Task<IActionResult> Post(CardDto model, long tarefaId)
    {
        try
        {
            var card = await _cardService.AddCard(model, tarefaId);
            if (card == null) return NoContent();

            return Ok(card);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar adicionar a Card. Erro: {ex.Message}");
        }
    }
    

    [HttpPost("{id}/{posicaoVertical}")]
    public async Task<IActionResult> PostVertical(long id, int posicaoVertical)
    {
        try
        {
            var card = await _cardService.UpdateCardVertical(id, posicaoVertical);

            if (card == null) return NoContent();

            return Ok(card);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar Cards. Erro: {ex.Message}");
        }
    }
     [HttpPost("{id}/{tarefaId}/{posicaoVertical}")]
    public async Task<IActionResult> PosyHorizontal(long id,long tarefaId, int posicaoVertical)
    {
        try
        {
            var card = await _cardService.UpdateCardHorizontal(id,tarefaId,posicaoVertical);
            
            if (card == null) return NoContent();

            return Ok(card);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar Cards. Erro: {ex.Message}");
        }
    }

}
