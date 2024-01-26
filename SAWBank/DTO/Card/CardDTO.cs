using SAWBank.DOMAIN.Entities;
using e = SAWBank.DOMAIN.Entities;
namespace SAWBank.API.DTO.Card
{
    public class CardDTO
    {
        public CardDTO(e.Card card)
        {
            id = card.Id;
            cardNumber = card.NumberCard;
            isBlocked = card.IsBlocked;
            accountId = card.AccountId;
            accountNumber = card.Account.AccountNumber;
        }

        public int id { get; init; }
        public string cardNumber { get; init; }
        public bool isBlocked { get; init; }
        public int accountId { get; init; }
        public string accountNumber { get; init; }
    }
}
