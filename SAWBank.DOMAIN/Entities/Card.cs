using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAWBank.DOMAIN.Entities
{
    public class Card
    {
        public int Id { get; set; }

        [Column(TypeName ="varchar(150)")]
        public required string NumberCard { get; set; }

        public required byte[] Pin { get; set; }
        public bool IsBlocked { get; set; } = false;

        public Account Account { get; set; } = null!;
    }
}
