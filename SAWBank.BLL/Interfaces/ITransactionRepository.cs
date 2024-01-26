using SAWBank.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAWBank.BLL.Interfaces
{
    public interface ITransactionRepository
    {
        Transaction Add(Transaction transaction);
        void Update(Transaction transaction);
        void Delete(Transaction transaction);
        List<Transaction>? FindAll();
        List<Transaction>? GetAllWithAccounts();
        void AddMoney(Transaction newTransaction, int accountDepo, int accountWithDraw);
    }
}
