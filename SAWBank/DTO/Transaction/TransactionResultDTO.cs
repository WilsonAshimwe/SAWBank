using SAWBank.API.DTO.Account;
using SAWBank.DOMAIN.Entities;

namespace SAWBank.API.DTO.Transaction
{
    public class TransactionResultDTO
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public TransactionTypeEnum TransactionType { get; set; }
        public int Amount { get; set; }

        public AccountDTO DepositAccount { get; set; } = null!;
        public AccountDTO WithdrawAccount { get; set; } = null!;
    }
}
