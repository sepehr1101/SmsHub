namespace SmsHub.Application.Features.Security.Handlers.Queries.Contracts
{
    public interface IApiKeyValidationHandler
    {
        Task<bool> Handle(string apiKey);
    }
}