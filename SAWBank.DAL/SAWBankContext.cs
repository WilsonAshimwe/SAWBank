using Microsoft.EntityFrameworkCore;
using SAWBank.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SAWBank.DAL
{
    public class SAWBankContext: DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        public SAWBankContext(DbContextOptions options ):base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder Builder)
        {
            Builder.Entity<Account>()
                .HasMany(a => a.DepositAccountTransactions)
                .WithOne(t => t.DepositAccount)
                .OnDelete(DeleteBehavior.NoAction);

            Builder.Entity<Account>()
                .HasMany(a => a.WithdrawAccountTransactions)
                .WithOne(t => t.WithdrawAccount)
                .OnDelete(DeleteBehavior.NoAction);

           //  Builder.Entity<Customer>().HasMany<Account>().WithMany( a=> a.Customers, pas obligé de le faire parceque la DB effacera seulement la relation dans la table intermediare

        }
    }
}
