using AutoMapper;
using MediatR;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Config.Commands.Contracts;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Application.Features.Config.Handlers.Commands.Create.Contracts;
using Azure.Core;
using FluentValidation;
using System.Threading;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Create.Implementations
{
    public class ConfigTypeGroupCreateHandler : IConfigTypeGroupCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IConfigTypeGroupCommandService _configTypeGroupCommandService;
        private readonly IValidator<CreateConfigTypeGroupDto> _validator;
        public ConfigTypeGroupCreateHandler(IConfigTypeGroupCommandService configTypeGroupCommandService, IMapper mapper, IValidator<CreateConfigTypeGroupDto> validator)
        {
            _configTypeGroupCommandService = configTypeGroupCommandService;
            _configTypeGroupCommandService.NotNull(nameof(_configTypeGroupCommandService));

            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }

        public async Task Handle(CreateConfigTypeGroupDto request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var createConfigTypeGroup = _mapper.Map<Entities.ConfigTypeGroup>(request);
            await _configTypeGroupCommandService.Add(createConfigTypeGroup);
        }
    }
}
