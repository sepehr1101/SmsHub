using SmsHub.Common.Contrats;
using SmsHub.Common.Extensions;
using SmsHub.Persistence.Features.Security.Queries.Contracts;
using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Domain.BaseDomainEntities.Id;

namespace SmsHub.Application.Features.Security.Handlers.Queries.Implementations
{
    public class ApiKeyValidationHandler : IApiKeyValidationHandler
    {
        private readonly ISecurityOperations _securityOperations;
        private readonly IServerUserQueryService _serverUserQueryService;
        public ApiKeyValidationHandler(ISecurityOperations securityOpertions, IServerUserQueryService serverUserQueryService)
        {
            _securityOperations = securityOpertions;
            _securityOperations.NotNull();

            _serverUserQueryService = serverUserQueryService;
            _serverUserQueryService.NotNull();
        }

        public async Task<bool> Handle(StringId apiKey)
        {
            var apiKeyHashed = await _securityOperations.GetSha512Hash(apiKey.apiKey);
            return await _serverUserQueryService.Any(apiKeyHashed);
        }
    }
}
