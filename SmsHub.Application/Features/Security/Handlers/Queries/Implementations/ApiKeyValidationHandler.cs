using SmsHub.Common.Contrats;
using SmsHub.Common.Extensions;
using SmsHub.Persistence.Features.Security.Queries.Contracts;
using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;

namespace SmsHub.Application.Features.Security.Handlers.Queries.Implementations
{
    public class ApiKeyValidationHandler : IApiKeyValidationHandler
    {
        private readonly ISecurityOpertions _securityOperations;
        private readonly IServerUserQueryService _serverUserQueryService;
        public ApiKeyValidationHandler(ISecurityOpertions securityOpertions, IServerUserQueryService serverUserQueryService)
        {
            _securityOperations = securityOpertions;
            _securityOperations.NotNull();

            _serverUserQueryService = serverUserQueryService;
            _serverUserQueryService.NotNull();
        }

        public async Task<bool> Handle(string apiKey)
        {
            var apiKeyHashed = await _securityOperations.GetSha512Hash(apiKey);
            return await _serverUserQueryService.Any(apiKeyHashed);
        }
    }
}
