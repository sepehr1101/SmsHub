﻿using AutoMapper;
using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Persistence.Features.Security.Queries.Contracts;

namespace SmsHub.Application.Features.Security.Handlers.Queries.Implementations
{
    public class ServerUserGetByApiKeyHandler : IServerUserGetByApiKeyHandler
    {
        private readonly IMapper _mapper;
        private readonly IServerUserQueryService _serverUserQueryService;
        public ServerUserGetByApiKeyHandler(
            IMapper mapper,
            IServerUserQueryService serverUserQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _serverUserQueryService = serverUserQueryService;
            _serverUserQueryService.NotNull(nameof(serverUserQueryService));
        }
        public async Task<GetServerUserDto> Handle(StringId apiKey)
        {
            var serverUser = await _serverUserQueryService.GetByApiKey(apiKey.ApiKey);
            return _mapper.Map<GetServerUserDto>(serverUser);
        }
    }
}
