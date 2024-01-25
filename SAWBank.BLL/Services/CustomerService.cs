using Microsoft.AspNetCore.Components.Web;
using SAWBank.BLL.Infrastructures;
using SAWBank.BLL.Interfaces;
using SAWBank.BLL.Templates;
using SAWBank.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SAWBank.BLL.Services
{
    public class CustomerService(
        IPersonRepository _personRepository, 
        ICompanyRepository _companyRepository, 
        IPasswordHasher _passwordHasher, 
        IAddressRepository _addressRepository,
        IAccountRepository _accountRepository,
        ICardRepository _cardRepository,
        IMailer _mailer,
        HtmlRenderer _htmlRenderer
        )
    {
        public Customer Register(string username, string password, string email, string phoneNumber, string street, string city, string streetNumber, string zipcode, string? additionalInfo, string? name, string? businesNumber, string? firstName, string? lastName, DateTime birthDate)
        {

            byte[] hash = _passwordHasher.Hash(email + password);

            Address address = _addressRepository.Add(new Address()
            {
                Street = street,
                City = city,
                AdditionalInfo = additionalInfo,
                StreetNumber = streetNumber,
                ZipCode = zipcode,
            });
            Customer customer;

            //currentAccount
            Account current_acc = CreateAccount(AccountTypeEnum.CurrentAccount);
            string card_pin = CreateCard(current_acc);

            //saving account
            CreateAccount(AccountTypeEnum.SavingAccount);


            if ((firstName is null || lastName is null) && (businesNumber is not null && name is not null))
            {
                customer = _companyRepository.Add(new Company()
                {
                    Username = username,
                    Password = hash,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    Image = null,
                    IsActive = true,
                    AddressId = address.Id,
                    BusinessNumber = businesNumber,
                    Name = name,
                    Accounts = new List<Account>()
                    {
                        CreateAccount(AccountTypeEnum.CurrentAccount)
                    }
                });
                SendRegistrationMail(customer, password, card_pin);
                return customer;
            }
            else
            {
                if (firstName is not null && lastName is not null )
                {
                    if (!(birthDate.Year < DateTime.Now.Year - 12))
                    {
                        throw new Exception("vous etes trop jeune");
                    }
                    customer = _personRepository.Add(new Person()
                    {
                        Username = username,
                        Password = hash,
                        Email = email,
                        PhoneNumber = phoneNumber,
                        Image = null,
                        IsActive = true,
                        AddressId = address.Id,
                        FirstName = firstName,
                        LastName = lastName,
                        BirthDate = birthDate
                    });
                    SendRegistrationMail(customer, password, card_pin);
                    return customer;
                }

            }

            throw new Exception();
           
        }

        public Account CreateAccount(AccountTypeEnum type)
        {
            Random rnd = new Random();

            string acc_numb = "BE-" + rnd.Next(10,100) + "-" + rnd.Next(1000,10000) + "-" + rnd.Next(100, 1000) + "-" + rnd.Next(1000, 10000);

            Account account = _accountRepository.Add(new Account()
            {
                CurrentBalance = 0,
                IsActive = true,
                IsSuspended = false,
                TypeId = type == AccountTypeEnum.CurrentAccount ? 1 : 2,
                AccountNumber = acc_numb
            });

            return account;
        }

        public string CreateCard(Account account)
        {
            if (account.TypeId == 1)
            {
                Random rnd = new Random();
                string pin = rnd.Next(1000, 10000).ToString();
                byte[] hash = _passwordHasher.Hash(account.AccountNumber + pin);
                Card card = _cardRepository.Add(new Card()
                {
                    NumberCard = "" + rnd.Next(1000,10000) + "-" + rnd.Next(1000, 10000) + "-" + rnd.Next(1000, 10000) + "-" + rnd.Next(1000, 10000),
                    Pin = hash,
                    IsBlocked = false,
                    AccountId = account.Id
                });

                return pin;
            }
            else
            {
                throw new Exception();
            }
        }

        private void SendRegistrationMail(Customer customer, string password, string cardPin)
        {
            string html = _htmlRenderer
                   .Render<RegisterCustomer>(new
                   {
                       CustomerName = customer.Username,
                       Password = password,
                       CardPin = cardPin
                   });
            _mailer.Send(customer.Email, "Inscription", html);
        }
    }
}
