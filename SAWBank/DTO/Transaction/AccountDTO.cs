using SAWBank.API.DTO.Account;

namespace SAWBank.API.DTO.Transaction
{
    public class AccountDTO
    {
        public int? Id { get; set; }
        //After we divide by 100
        public int CurrentBalance { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsSuspended { get; set; }
        public string AccountNumber { get; set; }
        public AccountTypeDTO Type { get; set; }
    }
}
