using AutoMapper;
using MediatR;
using SmsHub.Common;
using SmsHub.Domain.Features.Config.PersistenceDto.Commands;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Config.Commands.Create.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Create
{
    public class CreateConfigTypeGroupCommandHandler:IRequestHandler<CreateConfigTypeGroupDto>
    {
        private readonly IMapper _mapper;
        private readonly IConfigTypeGroupCommandService _configTypeGroupCommandService;
        public CreateConfigTypeGroupCommandHandler(IConfigTypeGroupCommandService configTypeGroupCommandService, IMapper mapper)
        {
            _configTypeGroupCommandService= configTypeGroupCommandService;
            _configTypeGroupCommandService.NotNull(nameof(_configTypeGroupCommandService));

            _mapper= mapper;    
            _mapper.NotNull(nameof(_mapper));
        }

        public async Task Handle(CreateConfigTypeGroupDto request, CancellationToken cancellationToken)
        {
            var createConfigTypeGroup = _mapper.Map<Entities.ConfigTypeGroup>(request);
            await _configTypeGroupCommandService.Add(createConfigTypeGroup);
        }
    }
}
