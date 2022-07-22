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

        public async Task<CardDto> AddCard(CardDto model)
        {
            try
            {
                var card = _mapper.Map<Card>(model);

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
    }
}