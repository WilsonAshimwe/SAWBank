using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAWBank.DOMAIN.Entities
{
    public class Transaction
    {
        public int? Id { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public TransactionTypeEnum TransactionType { get; set; }
        public int Amount { get; set; }

        public Account DepositAccount { get; set; } = null!;
        public Account WithdrawAccount { get; set; } = null!;
    }
        public enum TransactionTypeEnum
    {
        BankTransfer,
        Payment,
        StandingOrder
    }


}
