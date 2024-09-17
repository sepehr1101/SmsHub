using Microsoft.Extensions.DependencyInjection;
using SmsHub.Persistence.Contexts.Implementation;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Consumer.Commands.Contracts;
using SmsHub.Persistence.Features.Consumer.Commands.Implementations;
    
namespace SmsHub.Persistence.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceInjections(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, TestContext>();
            services.AddScoped<IConsumerCommandService, ConsumerCommandService>();
            return services;
        }
    }
}
