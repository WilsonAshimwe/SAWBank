using SAWBank.DOMAIN.Entities;
using System.ComponentModel.DataAnnotations;

namespace SAWBank.API.DTO.Customer
{
    public class CustomerUpdateDTO
    {
        [Required]
        public required string Username { get; set; }
        [Required]
        public required string Password { get; set; }
        [Required, EmailAddress]
        public required string Email { get; set; }
        [Required, RegularExpression(@"^\+320[24]\d{8}$")]
        public required string PhoneNumber { get; set; }
        [Required]
        public required string Street { get; set; }
        [Required]
        public required string City { get; set; }
        [Required, MaxLength(5)]
        public required string StreetNumber { get; set; }
        public string? AdditionnalInfo { get; set; }
        [Required, Range(1000, 9999)]
        public required string Zipcode { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Name { get; set; }
    }
}
