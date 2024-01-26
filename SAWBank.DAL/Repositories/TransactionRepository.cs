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
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        private readonly DbContext _context;
        public TransactionRepository(SAWBankContext context) : base(context)
        {
        }

        public void Delete(Transaction transaction)
        {
            _table.Remove(transaction);
        }

        public List<Transaction>? GetAllWithAccounts()
        {
            return _table
                .Include(a=> a.DepositAccount)
                .Include(a=> a.WithdrawAccount)
                .ToList();
        }
        public void AddMoney(Transaction newTransaction, int accountDepo, int accountWithDraw)
        {
            _table
                .Include(a => a.DepositAccount)
                .Include(a => a.WithdrawAccount)
                .Where(a => a.DepositAccount.Id == accountDepo)
                .Where(a=> a.WithdrawAccount.Id == accountWithDraw);
            _context.SaveChanges();
        }

    }
}
