using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAWBank.DOMAIN.Entities
{
    public abstract class Login
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required byte[] Password { get; set; }
        public abstract string Role { get; }
    }
}
