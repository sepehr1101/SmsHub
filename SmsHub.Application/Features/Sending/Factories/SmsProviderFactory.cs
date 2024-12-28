using Microsoft.Extensions.DependencyInjection;
using SmsHub.Application.Features.Sending.Services.Contracts;
using SmsHub.Application.Features.Sending.Services.Implementations;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;

namespace SmsHub.Application.Features.Sending.Factories
{
    public class SmsProviderFactory : ISmsProviderFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public SmsProviderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _serviceProvider.NotNull(nameof(serviceProvider));
        }
        public ISmsProvider Create(ProviderEnum providerEnum)
        {
            var dictionary = GetDictionary();
            var smsProvider = dictionary[providerEnum];
            return smsProvider;
        }
        private IDictionary<ProviderEnum, ISmsProvider> GetDictionary()
        {
            using (var scope = _serviceProvider.CreateScope())
            {       
                var dictionary = new Dictionary<ProviderEnum, ISmsProvider>
                {
                    { ProviderEnum.Magfa, scope.ServiceProvider.GetRequiredService<MagfaProvider>() },
                    { ProviderEnum.Kavenegar, scope.ServiceProvider.GetRequiredService<KavenegarProvider>() }
                };
                return dictionary;
            }            
        }
    }
}
