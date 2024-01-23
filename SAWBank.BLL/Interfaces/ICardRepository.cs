using SAWBank.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAWBank.BLL.Interfaces
{
    public interface ICardRepository
    {
        Card Add(Card card);
        void Update(Card card);
        void Delete(Card card);
    }
}
