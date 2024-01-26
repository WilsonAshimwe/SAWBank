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
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(SAWBankContext context) : base(context)
        {
        }

        public void Delete(Card card)
        {
            _table.Remove(card);
        }

        public List<Card> GetAllById(int customerId)
        {
            return _table.Where(c => c.Account.Customers.Any(customer => customer.Id == customerId)).ToList();
        }

        public Card? GetById(int customerId, int cardId)
        {
            return _table.Include(c => c.Account).Where(c => c.Account.Customers.Any(customer => customer.Id == customerId) && c.Id == cardId).FirstOrDefault();
        }
    }
}
