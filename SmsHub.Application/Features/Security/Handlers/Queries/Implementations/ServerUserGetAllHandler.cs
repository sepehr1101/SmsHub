using AutoMapper;
using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Persistence.Features.Security.Queries.Contracts;

namespace SmsHub.Application.Features.Security.Handlers.Queries.Implementations
{
    public class ServerUserGetAllHandler: IServerUserGetAllHandler
    {
        private readonly IMapper _mapper;
        private readonly IServerUserQueryService _serverUserQueryService;
        public ServerUserGetAllHandler(
            IMapper mapper, 
            IServerUserQueryService serverUserQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _serverUserQueryService = serverUserQueryService;
            _serverUserQueryService.NotNull(nameof(serverUserQueryService));
        }

        public async Task<ICollection<GetServerUserDto>> Handle()
        {
            var serverUsers = await _serverUserQueryService.GetAll();
            return _mapper.Map<ICollection<GetServerUserDto>>(serverUsers);
        }
    }
}
