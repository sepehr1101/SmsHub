using AutoMapper;
using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Persistence.Features.Security.Queries.Contracts;

namespace SmsHub.Application.Features.Security.Handlers.Queries.Implementations
{
    public class ServerUserGetByIdHandler: IServerUserGetByIdHandler
    {
        private readonly IMapper _mapper;
        private readonly IServerUserQueryService _serverUserQueryService;
        public ServerUserGetByIdHandler(
            IMapper mapper,
            IServerUserQueryService serverUserQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _serverUserQueryService = serverUserQueryService;
            _serverUserQueryService.NotNull(nameof(serverUserQueryService));
        }
        public async Task<GetServerUserDto> Handle(IntId Id)
        {
            var serverUser = await _serverUserQueryService.GetById(Id.Id);
            return _mapper.Map<GetServerUserDto>(serverUser);
        }
    }
}
