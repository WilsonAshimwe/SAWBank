using SAWBank.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAWBank.BLL.Interfaces
{
    public interface IAccountTypeRepository
    {
        AccountType Add(AccountType accountType);
        void Update(AccountType accountType);
        void Delete(AccountType accountType);
    }
}
