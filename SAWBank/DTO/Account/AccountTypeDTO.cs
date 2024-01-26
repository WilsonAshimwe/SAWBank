using SAWBank.DOMAIN.Entities;

namespace SAWBank.API.DTO.Account
{
    public class AccountTypeDTO
    {
        public int Id { get; set; }
        public required AccountTypeEnum Type { get; set; }
    }
}