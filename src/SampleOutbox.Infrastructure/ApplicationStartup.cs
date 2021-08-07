using Autofac;
using Microsoft.Extensions.Logging;
using SampleOutbox.Application.Configuration.Emails;
using SampleOutbox.Infrastructure.Database;
using SampleOutbox.Infrastructure.Domain;
using SampleOutbox.Infrastructure.Processing;

namespace SampleOutbox.Infrastructure
{
    public class ApplicationStartup
    {
        public static void Initialize(ContainerBuilder builder,
            string connectionString,
            IEmailSender emailSender, EmailSettings emailSettings, ILogger logger, bool runQuartz = true)
        {
            if (runQuartz)
            {
            }

            builder.RegisterModule(new DataAccessModule(connectionString));
            builder.RegisterModule(new MediatorModule());
            builder.RegisterModule(new DomainModule());

            // CompositionRoot.SetContainer(buildContainer);
        }
    }
}