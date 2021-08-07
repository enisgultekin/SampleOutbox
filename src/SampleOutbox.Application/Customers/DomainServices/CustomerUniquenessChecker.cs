using SampleOutbox.Application.Configuration.Data;
using SampleOutbox.Domain.Customers;

namespace SampleOutbox.Application.Customers.DomainServices
{
    public class CustomerUniquenessChecker : ICustomerUniquenessChecker
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public CustomerUniquenessChecker(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public bool IsUnique(string customerEmail)
        {
            //TODO : Bu kısma geri bak 
            return true;
        }
    }
}