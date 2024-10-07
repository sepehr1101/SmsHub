using AutoMapper;
using MediatR;
using SmsHub.Application.Common.Services.Contracts;
using SmsHub.Application.Features.Security.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Domain.Features.Security.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Security.Commands.Contracts;

namespace SmsHub.Application.Features.Security.Handlers.Commands.Create.Implementations
{
    public class ServerUserCreateHandler : IServerUserCreateHandler
    /*IRequestHandler<CreateServerUserDto, ApiKeyAndHash>*/
    {
        private readonly IMapper _mapper;
        private readonly IApiKeyFactory _apiKeyFactory;
        private readonly IServerUserCommandService _userCommandService;
        public ServerUserCreateHandler(
            IMapper mapper,
            IApiKeyFactory apiKeyFactory,
            IServerUserCommandService serverUserCommandService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _apiKeyFactory = apiKeyFactory;
            _apiKeyFactory.NotNull(nameof(apiKeyFactory));

            _userCommandService = serverUserCommandService;
            _userCommandService.NotNull(nameof(_userCommandService));
        }
        public async Task<ApiKeyAndHash> Handle(CreateServerUserDto request, CancellationToken cancellationToken)
        {
            var serverUser = _mapper.Map<ServerUser>(request);
            var apiKeyAndHash = await _apiKeyFactory.Create(serverUser.Username);
            serverUser.ApiKeyHash = apiKeyAndHash.Hash;
            await _userCommandService.Add(serverUser);
            return apiKeyAndHash;
        }
    }
}