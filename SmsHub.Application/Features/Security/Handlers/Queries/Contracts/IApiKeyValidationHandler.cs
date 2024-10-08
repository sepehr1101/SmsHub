using SmsHub.Application.Common.Base;

namespace SmsHub.Application.Features.Security.Handlers.Queries.Contracts
{
    public interface IApiKeyValidationHandler//:IRequestHandler<string, bool>
    {
        Task<bool> Handle(string apiKey);
    }
}