using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SampleOutbox.Application.Configuration;
using SampleOutbox.Application.Configuration.Emails;
using SampleOutbox.Infrastructure.Caching;
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


            builder.RegisterModule(new MediatorModule());

            // CompositionRoot.SetContainer(buildContainer);
        }
    }
}