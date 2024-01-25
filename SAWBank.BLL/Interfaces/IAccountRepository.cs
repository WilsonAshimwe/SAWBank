using SAWBank.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAWBank.BLL.Interfaces
{
    public interface IAccountRepository
    {
        Account Add(Account account);
        void Update(Account account);
        void Delete(Account account);

        Account? FindByNumberAccountInclundingAll(string accountNumber);
        List<Account>? GettAllAccountForCusomer(string email);
        List<Account>? FindAll();

        Account? FindByAccountNumber(int customerId, string accountNumber);
        Account? Find(params object[] id);

    }
}
