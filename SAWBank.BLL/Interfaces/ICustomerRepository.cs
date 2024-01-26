using SAWBank.DOMAIN.Entities;

namespace SAWBank.BLL.Interfaces
{
    public interface ICustomerRepository
    {
        Customer? Find(params object[] id);
        void Update(Customer customer);
    }
}
