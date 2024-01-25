using SAWBank.BLL.Interfaces;
using SAWBank.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAWBank.BLL.Services
{
    public class AccountServices (
        IAccountRepository _accountRepository 
        //ICardRepository cardRepository,
        //ITransactionRepository transactionRepository,
        //IPersonRepository personRepository, 
        //ICompanyRepository companyRepository
        )
    {
        //return All accounds without joins
        public List<Account>? GetAllTest()
        {
            return _accountRepository.FindAll();
        }

        public List<Account>? GettAllAccountForCusomer(string email)
        {
            return _accountRepository.GettAllAccountForCusomer(email);
        }

        public Account? FindByAccountNumber(int CustomerId,string accountNumber) 
        {
            return _accountRepository.FindByAccountNumber(CustomerId, accountNumber);
        }

    }
}
