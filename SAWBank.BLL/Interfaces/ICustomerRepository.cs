using SAWBank.DOMAIN.Entities;

namespace SAWBank.BLL.Interfaces
{
    public interface ICustomerRepository
    {
        Customer? Find(params object[] id);
        List<Customer> FindAll();
        List<Customer> FindAllWithInclude();
        void Update(Customer customer);
    }
}
