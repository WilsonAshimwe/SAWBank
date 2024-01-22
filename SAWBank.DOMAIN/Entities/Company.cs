using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAWBank.DOMAIN.Entities
{
    public class Company: Customer
    {
        [Column(TypeName ="nvarchar(150)")]
        public required string Name { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public required string BusinessNumber { get; set; }
        public override string Role { get => "COMPANY"; }
    }
}
