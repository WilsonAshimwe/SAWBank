using SAWBank.BLL.Interfaces;
using SAWBank.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAWBank.DAL.Repositories
{
    public class LoginRepository : BaseRepository<Customer>, ILoginRepository
    {
        public LoginRepository(SAWBankContext context) : base(context) { }

        public Customer? Get(string email)
        {
            return _table.FirstOrDefault(l => l.Email == email);
        }
    }
}
