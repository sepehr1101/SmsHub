using SmsHub.Application.Common.Base;
using SmsHub.Domain.BaseDomainEntities.Id;

namespace SmsHub.Application.Features.Security.Handlers.Queries.Contracts
{
    public interface IApiKeyValidationHandler//:IRequestHandler<string, bool>
    {
        Task<bool> Handle(string apiKey);
    }
}