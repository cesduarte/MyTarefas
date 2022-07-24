using AutoMapper;
using MyTarefas.Application.Contratos;
using MyTarefas.Application.Dtos;
using MyTarefas.Domain;
using MyTarefas.Persistence.Contrato;

namespace MyTarefas.Application
{
    public class CardService : ICardService
    {
        private readonly IGeralPersist _geralPersist;

        private readonly ICardPersist _cardPersist;

        private readonly IMapper _mapper;

        public CardService(ICardPersist cardPersist, IGeralPersist geralPersist, IMapper mapper)
        {
            _cardPersist = cardPersist;
            _geralPersist = geralPersist;
            _mapper = mapper;
        }

        public async Task<CardDto> AddCard(CardDto model, long tarefaId)
        {
            try
            {
                var card = _mapper.Map<Card>(model);

                card.TarefaId = tarefaId;

                _geralPersist.Add<Card>(card);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var cardRetorno = await _cardPersist.GetByCardIdAsync(model.Id);

                    return _mapper.Map<CardDto>(cardRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CardDto> UpdateCard(long cardId, CardDto model)
        {
            try
            {
                var card = await _cardPersist.GetByCardIdAsync(cardId);

                if (card == null) return null;

                model.Id = card.Id;

                _mapper.Map(model, card);

                _geralPersist.Update<Card>(card);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var cardRetorno = await _cardPersist.GetByCardIdAsync(model.Id);

                    return _mapper.Map<CardDto>(cardRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<CardDto> UpdateCardHorizontal(long cardId, long tarefaId)
        {
            try
            {
                var card = await _cardPersist.GetByCardIdAsync(cardId);

                if (card == null) return null;

                card.TarefaId = tarefaId;

                _geralPersist.Update<Card>(card);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var cardRetorno = await _cardPersist.GetByCardIdAsync(cardId);

                    return _mapper.Map<CardDto>(cardRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteCard(long cardId)
        {
            try
            {
                var card = await _cardPersist.GetByCardIdAsync(cardId);

                if (card == null) throw new Exception("card não encontrado.");

                _geralPersist.Delete<Card>(card);

                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CardDto[]> GetAllByTarefaIdAsync(long tarefaId)
        {
            var card = await _cardPersist.GetAllByTarefaIdAsync(tarefaId);

            if (card == null) return null;

            return _mapper.Map<CardDto[]>(card);
        }

        public async Task<CardDto[]> GetAllCardsAsync()
        {
            var card = await _cardPersist.GetAllCardsAsync();

            if (card == null) return null;

            return _mapper.Map<CardDto[]>(card);
        }

        public async Task<CardDto> UpdateCardHorizontal(long cardId, long tarefaId, int posicaoVertical)
        {
            Card cardAtual = await _cardPersist.GetByCardIdAsync(cardId);

            cardAtual.TarefaId = tarefaId;

            return await UpdateCard(cardAtual, posicaoVertical);
        }
        public async Task<CardDto> UpdateCardVertical(long cardId, int posicaoVertical)
        {

            Card cardAtual = await _cardPersist.GetByCardIdAsync(cardId);

            int posicaoAtual = cardAtual.posicaoVertical;

            return await UpdateCard(cardAtual, posicaoVertical, posicaoAtual);

        }
        private async Task<CardDto> UpdateCard(Card cardAtual, int posicaoVertical, int posicaoAtual = 0)
        {            

            cardAtual.posicaoVertical = posicaoVertical;

            _geralPersist.Update<Card>(cardAtual);

            Card[] cards = await _cardPersist.GetAllByTarefaIdAsync(cardAtual.TarefaId);

            if (posicaoVertical > posicaoAtual && posicaoAtual > 0)
            {

                cards = cards.Where(ca => ca.posicaoVertical > posicaoAtual).ToArray();

                for (int i = 0; i < cards.Length; i++)
                {
                    if (cards[i].posicaoVertical <= posicaoVertical)
                    {
                        cards[i].posicaoVertical = posicaoAtual;

                        _geralPersist.Update<Card>(cards[i]);

                        posicaoAtual++;
                    }
                }
            }
            else
            {
                cards = cards.Where(ca => ca.posicaoVertical >= posicaoVertical && ca.Id != cardAtual.Id).ToArray();

                for (int i = 0; i < cards.Length; i++)
                {
                    cards[i].posicaoVertical = posicaoVertical + (i + 1);

                    _geralPersist.Update<Card>(cards[i]);
                }
            }

            if (await _geralPersist.SaveChangesAsync())
            {
                var cardRetorno = await _cardPersist.GetByCardIdAsync(cardAtual.Id);

                return _mapper.Map<CardDto>(cardRetorno);
            }
            return null;
        }
    }
}