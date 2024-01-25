using SAWBank.DOMAIN.Entities;

namespace SAWBank.API.DTO.Account
{
    public class AccountListResultDTO
    {
        public int Id { get; set; }
        //After we divide by 100
        public int CurrentBalance { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsSuspended { get; set; }
        public string AccountNumber { get; set; }
        public AccountTypeDTO Type { get; set; }

        public List<CardDTO>? Cards { get; set; }

        public List<TransactionDTO>? DepositAccountTransactions { get; set; }

        public List<TransactionDTO>? WithdrawAccountTransactions { get; set; }

    }
}
