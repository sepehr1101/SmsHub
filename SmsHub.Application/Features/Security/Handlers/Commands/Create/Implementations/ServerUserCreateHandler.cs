using AutoMapper;
using FluentValidation;
using SmsHub.Application.Common.Services.Contracts;
using SmsHub.Application.Exceptions;
using SmsHub.Application.Features.Security.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Persistence.Features.Security.Commands.Contracts;

namespace SmsHub.Application.Features.Security.Handlers.Commands.Create.Implementations
{
    public class ServerUserCreateHandler : IServerUserCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IApiKeyFactory _apiKeyFactory;
        private readonly IServerUserCommandService _userCommandService;
        private readonly IValidator<CreateServerUserDto> _validator;
        public ServerUserCreateHandler(
            IMapper mapper,
            IApiKeyFactory apiKeyFactory,
            IServerUserCommandService serverUserCommandService,
            IValidator<CreateServerUserDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _apiKeyFactory = apiKeyFactory;
            _apiKeyFactory.NotNull(nameof(apiKeyFactory));

            _userCommandService = serverUserCommandService;
            _userCommandService.NotNull(nameof(_userCommandService));

            _validator= validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task<ApiKeyAndHash> Handle(CreateServerUserDto createServerUserDto, CancellationToken cancellationToken)
        {
            await CheckValidator(createServerUserDto, cancellationToken);

            var serverUser = _mapper.Map<ServerUser>(createServerUserDto);
            var apiKeyAndHash = await _apiKeyFactory.Create(serverUser.Username);
            serverUser.ApiKeyHash = apiKeyAndHash.Hash;
            await _userCommandService.Add(serverUser);
            return apiKeyAndHash;
        }
        private async Task CheckValidator(CreateServerUserDto createServerUserDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(createServerUserDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                var message = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new FluentValidationException(message);
            }
        }

    }
}