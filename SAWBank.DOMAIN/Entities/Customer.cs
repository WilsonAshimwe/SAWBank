using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAWBank.DOMAIN.Entities
{
    public abstract class Customer: Login
    {
        [Column(TypeName = "varchar(75)")]
        public required string Email { get; set; }
        [Column(TypeName = "varchar(15)")]
        public required string PhoneNumber { get; set; }
        public string? Image { get; set; }
        public bool IsActive { get; set; } = true;

        public required Address Address { get; set; }

        public List<Account> Accounts { get; set; } = null!;
    }
}
