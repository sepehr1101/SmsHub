﻿using AutoMapper;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Config.Queries.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Queries.Implementations
{
    public class ConfigGetListHandler : IConfigGetListHandler
    {
        private readonly IMapper _mapper;
        private readonly IConfigQueryService _configQueryService;
        public ConfigGetListHandler(
            IConfigQueryService configQueryService,
            IMapper mapper)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _configQueryService = configQueryService;
            _configQueryService.NotNull(nameof(configQueryService));
        }
        public async Task<ICollection<GetConfigDto>> Handle()
        {
            var configs = await _configQueryService.Get();
            return _mapper.Map<ICollection<GetConfigDto>>(configs);
        }
    }
}
