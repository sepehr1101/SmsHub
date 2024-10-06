using AutoMapper;
using MediatR;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Config.Commands.Contracts;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Application.Features.Config.Handlers.Commands.Create.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Create.Implementations
{
    public class CreateConfigTypeGroupCommandHandler : ICreateConfigTypeGroupCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IConfigTypeGroupCommandService _configTypeGroupCommandService;
        public CreateConfigTypeGroupCommandHandler(IConfigTypeGroupCommandService configTypeGroupCommandService, IMapper mapper)
        {
            _configTypeGroupCommandService = configTypeGroupCommandService;
            _configTypeGroupCommandService.NotNull(nameof(_configTypeGroupCommandService));

            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));
        }

        public async Task Handle(CreateConfigTypeGroupDto request, CancellationToken cancellationToken)
        {
            var createConfigTypeGroup = _mapper.Map<Entities.ConfigTypeGroup>(request);
            await _configTypeGroupCommandService.Add(createConfigTypeGroup);
        }
    }
}
