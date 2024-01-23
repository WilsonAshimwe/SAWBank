using Microsoft.EntityFrameworkCore;
using SAWBank.DAL.Seeders;
using SAWBank.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

            Builder.Entity<Customer>().HasIndex(c => c.Email).IsUnique();
            Builder.Entity<Customer>().HasIndex(c => c.Username).IsUnique();
            Builder.Entity<Company>().HasIndex(c => c.BusinessNumber).IsUnique();
            Builder.Entity<Account>().HasIndex(ac => ac.AccountNumber).IsUnique();
            Builder.Entity<Card>().HasIndex(ac => ac.NumberCard).IsUnique();

            #region Add Seeders

            Builder.Entity<Person>().HasData(DataSeeders.InitPeople());
            Builder.Entity<Company>().HasData(DataSeeders.InitCompanies());
            Builder.Entity<AccountType>().HasData(DataSeeders.InitAccountType());
            Builder.Entity<Account>().HasData(DataSeeders.InitAccounts());
            Builder.Entity<Card>().HasData(DataSeeders.InitCards());

            #endregion

        }
    }
}
