using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Peekage.ContactManagement.Service.Domain.Models.Contacts;
using Peekage.ContactManagement.Service.Infrastructure.MongoPersistence;
using Peekage.ContactManagement.Service.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Peekage.ContactManagement.Service.Framework
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddScoped<IContactRepository, ContactRepository>();
        }

        public static IServiceCollection AddCommandBus(this IServiceCollection services)
        {
            return services.AddScoped<ICommandBus, CommandBus>();
        }

        public static IServiceCollection AddCommandHandlers(this IServiceCollection services,
            Assembly assembly)
        {
            assembly
            .GetTypes()
            .Where(item => item.GetInterfaces()
            .Where(i => i.IsGenericType).Any(i => i.GetGenericTypeDefinition() == typeof(ICommandHandler<>))
            && !item.IsAbstract && !item.IsInterface)
            .ToList()
            .ForEach(assignedTypes =>
            {
                var serviceType = assignedTypes.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(ICommandHandler<>));
                services.AddScoped(serviceType, assignedTypes);
            });
            return services;
        }

        public static IServiceCollection AddQueryServices(this IServiceCollection services)
        {
            return services.AddScoped<IContactsQueryService, ContactsMongoQueryService>();
        }

        public static IServiceCollection AddMongoDB(this IServiceCollection services,
            IConfiguration configuration)
        {
            new ContactMappings().Register();
            services.AddTransient<IMongoDatabase>((s) =>
            {
                var client = new MongoClient(configuration["MongoDB:ConnectionString"]);
                return client.GetDatabase(configuration["MongoDB:DbName"]);
            });
            return services;
        }
    }
}
