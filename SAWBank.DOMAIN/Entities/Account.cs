using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAWBank.DOMAIN.Entities
{
    public class Account
    {
        public int Id { get; set; }
        
        //After we divide by 100
        public int CurrentBalance { get; set; } =0;

        public bool IsActive { get; set; } = true;

        public bool IsSuspended { get; set; }

        public int AccountId { get; set; }
        [ForeignKey("TypeId")]
        public AccountType Type { get; set; } = null!;

        public List<Card> Cards { get; set; } = null!;

        public List<Customer> Customers { get; set; } = null!;

        [InverseProperty("DepositAccount")]
        public List<Transaction>? DepositAccountTransactions { get; set; }

        [InverseProperty("WithdrawAccount")]
        public List<Transaction>? WithdrawAccountTransactions { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string AccountNumber { get; set; } = null!;



    }
}
