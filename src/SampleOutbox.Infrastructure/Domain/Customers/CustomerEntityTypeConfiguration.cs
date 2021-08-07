using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleOutbox.Domain.Customers;
using SampleOutbox.Infrastructure.Database;

namespace SampleOutbox.Infrastructure.Domain.Customers
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers",SchemaNames.Orders);

            builder.HasKey(b => b.Id);
            builder.Property("_email").HasColumnName("Email");
            builder.Property("_name").HasColumnName("Name");
            builder.Property("_welcomeEmailWasSent").HasColumnName("WelcomeEmailWasSent");
        }
    }
}