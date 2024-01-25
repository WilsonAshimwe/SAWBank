using SAWBank.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAWBank.BLL.Interfaces
{
    public interface IPersonRepository
    {
        Person Add(Person person);
        void Update(Person person);
        void Delete(Person person);
        Person? Find(params object[] id);
    }
}
