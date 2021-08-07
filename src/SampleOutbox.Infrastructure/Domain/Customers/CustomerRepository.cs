using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleOutbox.Domain.Customers;
using SampleOutbox.Infrastructure.Database;

namespace SampleOutbox.Infrastructure.Domain.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly OrdersContext _context;

        public CustomerRepository(OrdersContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(Customer customer)
        {
            await this._context.Customers.AddAsync(customer);
        }

        public async Task<Customer> GetByIdAsync(CustomerId id)
        {
            return await this._context.Customers
                .SingleAsync(x => x.Id == id);
        }
    }
}