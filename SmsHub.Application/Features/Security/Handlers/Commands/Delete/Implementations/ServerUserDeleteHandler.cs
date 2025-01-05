using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Security.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Persistence.Features.Security.Commands.Contracts;
using SmsHub.Persistence.Features.Security.Queries.Contracts;

namespace SmsHub.Application.Features.Security.Handlers.Commands.Delete.Implementations
{
    public class ServerUserDeleteHandler : IServerUserDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IServerUserCommandService _serverUserCommandService;
        private readonly IServerUserQueryService _serverUserQueryService;
        public ServerUserDeleteHandler(
            IMapper mapper,
            IServerUserCommandService serverUserCommandService,
            IServerUserQueryService serverUserQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _serverUserCommandService = serverUserCommandService;
            _serverUserCommandService.NotNull(nameof(serverUserCommandService));

            _serverUserQueryService = serverUserQueryService;
            _serverUserQueryService.NotNull(nameof(serverUserQueryService));
        }
        public async Task Handle(DeleteServerUserDto deleteServerUserDto, CancellationToken cancellationToken)
        {
            var serverUser = await _serverUserQueryService.GetById(deleteServerUserDto.Id);
            _serverUserCommandService.Delete(serverUser);
        }
    }
}
