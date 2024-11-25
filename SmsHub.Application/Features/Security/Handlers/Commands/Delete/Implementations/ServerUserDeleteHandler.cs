using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Security.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Security.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Security.Commands.Contracts;
using SmsHub.Persistence.Features.Security.Queries.Contracts;

namespace SmsHub.Application.Features.Security.Handlers.Commands.Delete.Implementations
{
    public class ServerUserDeleteHandler : IServerUserDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IServerUserCommandService _serverUserCommandService;
        private readonly IServerUserQueryService _serverUserQueryService;
        private readonly IValidator<DeleteServerUserDto> _validator;
        public ServerUserDeleteHandler(
            IMapper mapper,
            IServerUserCommandService serverUserCommandService,
            IServerUserQueryService serverUserQueryService,
            IValidator<DeleteServerUserDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _serverUserCommandService = serverUserCommandService;
            _serverUserCommandService.NotNull(nameof(serverUserCommandService));

            _serverUserQueryService = serverUserQueryService;
            _serverUserQueryService.NotNull(nameof(serverUserQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(DeleteServerUserDto deleteServerUserDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(deleteServerUserDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var serverUser = await _serverUserQueryService.GetById(deleteServerUserDto.Id);
            _serverUserCommandService.Delete(serverUser);
        }
    }
}
