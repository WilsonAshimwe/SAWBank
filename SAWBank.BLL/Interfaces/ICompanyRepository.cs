using SAWBank.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAWBank.BLL.Interfaces
{
    public interface ICompanyRepository
    {
        Company Add(Company company);
        void Update(Company company);
        void Delete(Company company);
        Company? Find(params object[] id);
    }
}
