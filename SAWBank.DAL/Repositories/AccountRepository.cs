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
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(DbContext context) : base(context)
        {
        }
        public override Account? Find(params object[] id)
        {
            return _table
                .Include(a => a.Type)
                .FirstOrDefault(a => a.Id == (int)id[0]);
        }
        public void Delete(Account account)
        {
            _table.Remove(account);
        }

        public Account? FindByIdInclundingAll(params object[] id)
        {
            return _table
                .Include(a => a.Type)
                .Include(a => a.Cards)
                .Include(a => a.DepositAccountTransactions)
                .Include(a => a.WithdrawAccountTransactions)
                .FirstOrDefault(a => a.Id == (int)id[0]);

        }
    }
}
