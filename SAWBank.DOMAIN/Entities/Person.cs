using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAWBank.DOMAIN.Entities
{
    public class Person : Customer
    {
        [Column(TypeName = "varchar(50)")]
        public required string FirstName { get; set; }

        [Column(TypeName = "nvarchar(75)")]
        public required string LastName { get; set; }
       
        public required DateTime BirthDate { get; set; }
        public override string Role { get => "PERSON"; }
    }
}
