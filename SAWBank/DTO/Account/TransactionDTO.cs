using SAWBank.DOMAIN.Entities;

namespace SAWBank.API.DTO.Account
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public TransactionTypeEnum TransactionType { get; set; }
        public int Amount { get; set; }
    }
}