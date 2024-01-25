using System.ComponentModel.DataAnnotations;

namespace SAWBank.API.DTO.CustomerDTO
{
    public class RegisterCustomerDTO
    {
        [Required]
        public string Username { get; set; }
    }
}
