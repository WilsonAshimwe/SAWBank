using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAWBank.DOMAIN.Entities
{
    [Table("Customers")]
    public abstract class Customer
    {

        public int Id { get; set; }
        public required string Username { get; set; }
        public required byte[] Password { get; set; }
        public abstract string Role { get; }
        [Column(TypeName = "varchar(75)")]
        public required string Email { get; set; }
        [Column(TypeName = "varchar(15)")]
        public required string PhoneNumber { get; set; }
        public string? Image { get; set; }
        public bool IsActive { get; set; } = true;

        public int AddressId { get; set; }
        [ForeignKey("AddressId")]
        public Address Address { get; set; } = null!;

        public List<Account> Accounts { get; set; } = null!;
    }
}
