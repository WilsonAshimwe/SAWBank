using Microsoft.EntityFrameworkCore;
using SAWBank.BLL.Interfaces;
using SAWBank.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAWBank.DAL.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SAWBankContext context) : base(context)
        {
        }

        public override Customer? Find(params object[] id)
        {
            return _table
                .Include(c => c.Address)
                .Include(c => c.Accounts)
                .FirstOrDefault(c => c.Id == (int)id[0]);
        }

        public List<Customer> FindAllWithInclude()
        {
            return _table.Include(c=>c.Address).Include(c => c.Accounts).ToList();
        }
    }
}
