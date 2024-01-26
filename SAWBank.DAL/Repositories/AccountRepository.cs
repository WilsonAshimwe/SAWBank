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
        public AccountRepository(SAWBankContext context) : base(context)
        {
        }
        public override Account? Find(params object[] id)
        {
            //Find By Id Inclunding All
            return _table
                .Include(a => a.Type)
                .Include(a => a.Cards)
                .Include(a => a.DepositAccountTransactions)
                .Include(a => a.WithdrawAccountTransactions)
                .Include(a=> a.Customers)
                .FirstOrDefault(a => a.Id == (int)id[0]);
        }
        public void Delete(Account account)
        {
            _table.Remove(account);
        }

        public Account? FindByNumberAccountInclundingAll(string accountNumber)
        {
            return _table
              .Include(a => a.Customers)
              .Include(a => a.Type)
              .Include(a => a.Cards)
              .Include(a => a.DepositAccountTransactions)
              .Include(a => a.WithdrawAccountTransactions)
              .FirstOrDefault(a => a.AccountNumber == accountNumber);

        }

        public List<Account>? GettAllAccountForCusomer(string email)
        {
            // left join
            //return _table
            //    .Include(a => a.Customers.Where(c => c.Email == email))
            //    .Include(a => a.Type)
            //    .Include(a => a.Cards)
            //    .Include(a=> a.DepositAccountTransactions)
            //    .Include(a=> a.WithdrawAccountTransactions)
            //    .Where(a=> a.Customers.Count >0)
            //    .ToList();

            //inner join
            return _table
                .Include(a => a.Customers)
                .Include(a => a.Type)
                .Include(a => a.Cards)
                .Include(a => a.DepositAccountTransactions)
                .Include(a => a.WithdrawAccountTransactions)
                .Where(a => a.Customers.Any(c => c.Email == email))
                .ToList();


        }

        public Account? FindByAccountNumber(int customerId, string accountNumber)
        {
            return _table
                .Include(a => a.Customers)
                .Include(a => a.Type)
                .Include(a => a.Cards)
                .Include(a => a.DepositAccountTransactions)
                .Include(a => a.WithdrawAccountTransactions)
                .Where(a => a.Customers.Any(c => c.Id == customerId))
                .FirstOrDefault(a=> a.AccountNumber == accountNumber);
        }
    }
}
