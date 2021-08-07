using System;
using SampleOutbox.Domain.SeedWork;

namespace SampleOutbox.Domain.Customers
{
    public class Customer : Entity, IAggregateRoot
    {
        public CustomerId Id { get; private set; }

        private string _email;

        private string _name;

        // private readonly List<Order> _orders;

        private bool _welcomeEmailWasSent;

        private Customer()
        {
            
        }

        private Customer(string name, string email)
        {
            this.Id = new CustomerId(Guid.NewGuid());
            _email = email;
            _name = name;
            _welcomeEmailWasSent = false;
            // _orders = new List<Order>();
        }
        
        public static Customer CreateRegistered(
            string email, 
            string name,
            ICustomerUniquenessChecker customerUniquenessChecker)
        {
            // CheckRule(new CustomerEmailMustBeUniqueRule(customerUniquenessChecker, email));

            return new Customer(email, name);
        }
    }
}