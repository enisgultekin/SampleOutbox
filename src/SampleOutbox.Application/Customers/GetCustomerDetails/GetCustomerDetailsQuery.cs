using System;
using SampleOutbox.Application.Configuration.Queries;
using SampleOutbox.Domain.Customers;

namespace SampleOutbox.Application.Customers.GetCustomerDetails
{
    public class GetCustomerDetailsQuery : IQuery<CustomerDetailsDto>
    {
        public GetCustomerDetailsQuery(Guid customerId)
        {
            CustomerId = customerId;
        }

        public Guid CustomerId { get;  }
    }
}