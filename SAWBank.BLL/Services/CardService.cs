using SAWBank.BLL.Interfaces;
using SAWBank.DOMAIN.Entities;

namespace SAWBank.BLL.Services
{
    public class CardService(ICardRepository _cardRepository)
    {
        public void Blockcard(int customerId, int cardId)
        {
            Card? c = GetById(customerId, cardId);

            if (c is null)
            {
                throw new KeyNotFoundException($"No card (owned by user) with the following id has been found : {cardId}");
            }

            c.IsBlocked = true;
            _cardRepository.Update(c);
        }

        public void UnBlockcard(int customerId, int cardId)
        {
            Card? c = GetById(customerId, cardId);

            if (c is null)
            {
                throw new KeyNotFoundException($"No card (owned by user) with the following id has been found : {cardId}");
            }

            c.IsBlocked = false;
            _cardRepository.Update(c);
        }

        public List<Card> GetAllCustomerCards(int customerId)
        {
            return _cardRepository.GetAllById(customerId);
        }

        public Card GetById(int customerId ,int cardId)
        {
            Card? card = _cardRepository.GetById(customerId, cardId);
            if (card is null)
            {
                throw new KeyNotFoundException($"No cards with id : {cardId} for current user");
            }
            return card;
        }
    }
}
