using SAWBank.API.DTO.Account;
using SAWBank.DOMAIN.Entities;
using e = SAWBank.DOMAIN.Entities;
namespace SAWBank.API.DTO.Customer
{
    public class CustomerDTO
    {
        public CustomerDTO(e.Customer customer)
        {
            Id = customer.Id;
            Username = customer.Username;
            Phonenumber = customer.PhoneNumber;
            Image = customer.Image;
            Address = customer.Address;
            Role = customer.Role;
        }
        public CustomerDTO(e.Customer customer, e.Person person) : this(customer)
        {
            FirstName = person.FirstName;
            LastName = person.LastName;
            BirthDate = person.BirthDate;
        }

        public CustomerDTO(e.Customer customer, e.Company company) : this(customer)
        {
            Name = company.Name;
            BuisinessNumber = company.BusinessNumber;
        }

        public int Id { get; init; }
        public string Username { get; init; }
        public string Phonenumber { get; init; }
        public string? Image { get; init; }
        public Address Address { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public DateTime? BirthDate { get; init; }
        public string? Name { get; init; }
        public string? BuisinessNumber { get; init; }
        public string Role {  get; init; }
    }
}
