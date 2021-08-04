using SampleOutbox.Application.Configuration.Commands;

namespace SampleOutbox.Application.Customers.RegisterCustomer
{
    public class RegisterCustomerCommand : CommandBase<CustomerDto>
    {
        public string Email { get; set; }
        public string Name { get; set; }

        public RegisterCustomerCommand(string email, string name)
        {
            this.Email = email;
            this.Name = name;
        }
    }
}