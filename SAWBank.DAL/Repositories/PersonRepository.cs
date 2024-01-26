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
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(SAWBankContext context) : base(context)
        {
        }

        public override Person? Find(params object[] id)
        {
            return _table
                .Include( p => p.Address)
                .Include(p => p.Accounts)
                .FirstOrDefault(c => c.Id == (int)id[0]);
        }

        public void Delete(Person person)
        {
             _table.Remove(person);
        }
    }
}
