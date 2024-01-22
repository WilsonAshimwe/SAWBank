using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAWBank.DOMAIN.Entities
{
    public class AccountType
    {
        public int Id { get; set; }
        public required AccountTypeEnum Type { get; set; }


        public List<Account> Accounts { get; set; } = null!;

    }

    public enum AccountTypeEnum
    {
        CurrentAccount,
        SavingAccount,
    }
}
