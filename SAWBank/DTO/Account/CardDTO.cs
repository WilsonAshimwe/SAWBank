using System.ComponentModel.DataAnnotations.Schema;

namespace SAWBank.API.DTO.Account
{
    public class CardDTO
    {
        public int Id { get; set; }
        public required string NumberCard { get; set; }
        public required byte[] Pin { get; set; }
        public bool IsBlocked { get; set; } = false;
    }
}