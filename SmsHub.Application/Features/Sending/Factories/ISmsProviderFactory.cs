using SmsHub.Application.Features.Sending.Services.Contracts;
using SmsHub.Domain.Constants;

namespace SmsHub.Application.Features.Sending.Factories
{
    public interface ISmsProviderFactory
    {
        ISmsProvider Create(ProviderEnum providerEnum);
    }
}