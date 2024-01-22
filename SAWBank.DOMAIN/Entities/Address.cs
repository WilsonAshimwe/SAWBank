using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAWBank.DOMAIN.Entities
{
    public class Address
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(150)")]
        public required string Street { get; set; }

        [Column(TypeName = "varchar(75)")]
        public required string City { get; set; }

        [Column(TypeName = "varchar(5)")]
        public required string StreetNumber { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string? AdditionalInfo { get; set; }

        [Column(TypeName = "char(4)")]
        public required string ZipCode { get; set; }


    }
}
