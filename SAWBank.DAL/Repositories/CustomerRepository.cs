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
    }
}
