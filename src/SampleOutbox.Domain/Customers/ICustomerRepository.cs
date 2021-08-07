using System.Threading.Tasks;

namespace SampleOutbox.Domain.Customers
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(CustomerId id);
        Task AddAsync(Customer customer);
    }
}