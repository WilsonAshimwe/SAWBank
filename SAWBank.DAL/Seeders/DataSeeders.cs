using SAWBank.BLL.Infrastructures;
using SAWBank.DOMAIN.Entities;

namespace SAWBank.DAL.Seeders
{
    public class DataSeeders
    {
        public static IEnumerable<Person> InitPeople()
        {
            yield return new Person()
            {
                Id = 1, Username = "stef", Email = "stef@test.com", Password = new PasswordHasher().Hash("stef@test.com" + "1234"),
                PhoneNumber = "+320413234567", Image = null, IsActive = true, Address = new Address() { Id = 1, Street = "Rue blablabla", City = "Bruxelles", StreetNumber = "5", ZipCode = "1000", AdditionalInfo = null },
                FirstName = "Stefania", LastName = "Méchante", BirthDate = new DateTime(1900, 02, 16, 17, 13, 04, 374)
            };
            yield return new Person() 
            { 
                Id = 2, Username = "wil", Email = "wil@test.com", Password = new PasswordHasher().Hash("wil@test.com" + "4567"), 
                PhoneNumber = "+320423234789", Image = null, IsActive = true, Address = new Address() { Id = 2, Street = "Rue nononono", City = "Londre", StreetNumber = "43B", ZipCode = "8513", AdditionalInfo = null }, 
                FirstName = "Wilson", LastName = "Python Expert", BirthDate = new DateTime(1930, 05, 21, 17, 13, 04, 374)
            };
            yield return new Person() 
            { 
                Id = 3, Username = "ad", Email = "ad@test.com", Password = new PasswordHasher().Hash("ad@test.com" + "7890"), 
                PhoneNumber = "+320473568123", Image = null, IsActive = true, Address = new Address() { Id = 3, Street = "Rue hihihihi", City = "Bruxelles", StreetNumber = "777", ZipCode = "3657", AdditionalInfo = null }, 
                FirstName = "Adam", LastName = "Number One", BirthDate = new DateTime(1996, 07, 17, 17, 13, 04, 374) 
            };
        }

        public static IEnumerable<Company> InitCompanies()
        {
            
            yield return new Company() 
            { 
                Id = 4, Username = "Delheize", Email = "delheize@supermarket.com", Password = new PasswordHasher().Hash("delheize@supermarket.com" + "1234"), 
                PhoneNumber = "+320489234321", Image = null, IsActive = true, Address = new Address() { Id = 4, Street = "Rue delhaize", City = "Bruxelles", StreetNumber = "21", ZipCode = "1000", AdditionalInfo = null }, 
                Name = "Delheize", BusinessNumber = "BE 0123.456.789" 
            };
            yield return new Company() 
            { 
                Id = 5, Username = "Github", Email = "github@info.com", Password = new PasswordHasher().Hash("github@info.com" + "1234"), 
                PhoneNumber = "+320489234333", Image = null, IsActive = true, Address = new Address() { Id = 5, Street = "Rue repository", City = "Bruxelles", StreetNumber = "156", ZipCode = "1000", AdditionalInfo = null }, 
                Name = "Github", BusinessNumber = "BE 3456.789.012" 
            };
            yield return new Company() 
            { 
                Id = 6, Username = "DC", Email = "digitalcity@info.com", Password = new PasswordHasher().Hash("digitalcity@info.com" + "1234"), 
                PhoneNumber = "+320489232222", Image = null, IsActive = true, Address = new Address() { Id = 6, Street = "Rue formation", City = "Bruxelles", StreetNumber = "98a", ZipCode = "1000", AdditionalInfo = null }, 
                Name = "Digital City", BusinessNumber = "BE 3210.987.654" 
            };
        }

        public static IEnumerable<AccountType> InitAccountType()
        {
            yield return new AccountType() { Id = 1, Type = AccountTypeEnum.CurrentAccount };
            yield return new AccountType() { Id = 2, Type = AccountTypeEnum.SavingAccount };
        }

        public static IEnumerable<Account> InitAccounts()
        {
            yield return new Account()
            {
                Id = 1,
                CurrentBalance = 10000,
                IsActive = true,
                IsSuspended = false,
                Type = InitAccountType().ToArray()[0],
                Customers = new List<Customer>(){InitPeople().ToArray()[0]},
                AccountNumber = "BE-22-1111-333-4444"
            };
            yield return new Account()
            {
                Id = 2,
                CurrentBalance = 500,
                IsActive = true,
                IsSuspended = false,
                Type = InitAccountType().ToArray()[1],
                Customers = new List<Customer>() { InitPeople().ToArray()[0] },
                AccountNumber = "BE-22-1111-333-5555"
            };
            yield return new Account()
            {
                Id = 3,
                CurrentBalance = 400000,
                IsActive = true,
                IsSuspended = false,
                Type = InitAccountType().ToArray()[0],
                Customers = new List<Customer>() { InitPeople().ToArray()[1] },
                AccountNumber = "BE-22-1111-333-4888"
            };
            yield return new Account()
            {
                Id = 4,
                CurrentBalance = 0,
                IsActive = true,
                IsSuspended = false,
                Type = InitAccountType().ToArray()[0],
                Customers = new List<Customer>() { InitPeople().ToArray()[2] },
                AccountNumber = "BE-22-1111-444-4444"
            };
            yield return new Account()
            {
                Id = 5,
                CurrentBalance = 100000000,
                IsActive = true,
                IsSuspended = false,
                Type = InitAccountType().ToArray()[0],
                Customers = new List<Customer>() { InitCompanies().ToArray()[0] },
                AccountNumber = "BE-22-1111-383-4444"
            };
            yield return new Account()
            {
                Id = 6,
                CurrentBalance = 200000000,
                IsActive = true,
                IsSuspended = false,
                Type = InitAccountType().ToArray()[0],
                Customers = new List<Customer>() { InitCompanies().ToArray()[1] },
                AccountNumber = "BE-24-1111-333-4444"
            };
            yield return new Account()
            {
                Id = 7,
                CurrentBalance = 500,
                IsActive = true,
                IsSuspended = false,
                Type = InitAccountType().ToArray()[0],
                Customers = new List<Customer>() { InitCompanies().ToArray()[2] },
                AccountNumber = "BE-22-1177-333-4444"
            };

        }

        public static IEnumerable<Card> InitCards()
        {
            yield return new Card() 
            { 
                Id = 1,
                NumberCard = "0000-1234-5678-9012",
                Pin = new PasswordHasher().Hash("0000-1234-5678-9012" + "0000"),
                IsBlocked = false,
                Account = InitAccounts().ToArray()[0],
            };
            yield return new Card()
            {
                Id = 2,
                NumberCard = "1111-1234-5678-9012",
                Pin = new PasswordHasher().Hash("1111-1234-5678-9012" + "1111"),
                IsBlocked = false,
                Account = InitAccounts().ToArray()[2],
            };
            yield return new Card()
            {
                Id = 3,
                NumberCard = "2222-1234-5678-9012",
                Pin = new PasswordHasher().Hash("2222-1234-5678-9012" + "2222"),
                IsBlocked = false,
                Account = InitAccounts().ToArray()[3],
            };
            yield return new Card()
            {
                Id = 4,
                NumberCard = "3333-1234-5678-9012",
                Pin = new PasswordHasher().Hash("3333-1234-5678-9012" + "3333"),
                IsBlocked = false,
                Account = InitAccounts().ToArray()[4],
            };
            yield return new Card()
            {
                Id = 5,
                NumberCard = "4444-1234-5678-9012",
                Pin = new PasswordHasher().Hash("4444-1234-5678-9012" + "4444"),
                IsBlocked = false,
                Account = InitAccounts().ToArray()[5],
            };
            yield return new Card()
            {
                Id = 6,
                NumberCard = "5555-1234-5678-9012",
                Pin = new PasswordHasher().Hash("5555-1234-5678-9012" + "5555"),
                IsBlocked = false,
                Account = InitAccounts().ToArray()[6],
            };
        }

    }
}