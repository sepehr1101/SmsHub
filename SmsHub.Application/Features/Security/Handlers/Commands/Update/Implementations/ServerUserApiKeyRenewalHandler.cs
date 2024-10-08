using SmsHub.Application.Common.Services.Contracts;
using SmsHub.Application.Features.Security.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Persistence.Features.Security.Commands.Contracts;
using SmsHub.Persistence.Features.Security.Queries.Contracts;

namespace SmsHub.Application.Features.Security.Handlers.Commands.Update.Implementations
{
    public class ServerUserApiKeyRenewalHandler : IServerUserApiKeyRenewalHandler
    {
        private readonly IServerUserCommandService _userCommandService;
        private readonly IServerUserQueryService _userQueryService;
        private readonly IApiKeyFactory _apiKeyFactory;
        public ServerUserApiKeyRenewalHandler(
            IServerUserCommandService userCommandService,
            IServerUserQueryService userQueryService,
            IApiKeyFactory apiKeyFactory)
        {
            _userCommandService = userCommandService;
            _userCommandService.NotNull(name: nameof(apiKeyFactory));

            _userQueryService = userQueryService;
            _userQueryService.NotNull(name: nameof(apiKeyFactory));

            _apiKeyFactory = apiKeyFactory;
            _apiKeyFactory.NotNull(name: nameof(apiKeyFactory));
        }
        public async Task<ApiKeyAndHash> Handle(int id)
        {
            var serverUser = await _userQueryService.GetById(id);
            var apiKeyAndHash = await _apiKeyFactory.Create(serverUser.Username);
            await _userCommandService.UpdateApiKey(id, apiKeyAndHash.Hash);
            return apiKeyAndHash;
        }
    }
}