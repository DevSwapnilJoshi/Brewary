using EGlossary.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGlossary.Domain.InterfaceReposistory
{
    public interface ICustomerReposistory
    {
        Task GetCustmoreInMemory();

        Task<IEnumerable<CustomerEntity>> GetCustomers();

        Task<CustomerEntity> GetCustomerById(int Id);

        Task<int> CreateCustomer(CustomerEntity customer);

        Task<bool> DeleteCustomer(int Id);
    }
}