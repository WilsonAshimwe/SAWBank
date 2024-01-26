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
    public class AccountTypeRepository : BaseRepository<AccountType>, IAccountTypeRepository
    {
        public AccountTypeRepository(SAWBankContext context) : base(context)
        {
        }

        public void Delete(AccountType accountType)
        {
            _table.Remove(accountType);
        }
    }
}
