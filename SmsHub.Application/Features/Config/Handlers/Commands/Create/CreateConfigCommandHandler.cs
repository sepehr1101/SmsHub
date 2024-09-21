using AutoMapper;
using MediatR;
using SmsHub.Common;
using SmsHub.Domain.Features.Config.PersistenceDto.Commands;
using SmsHub.Persistence.Features.Config.Commands.Create.Contracts;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Create
{
    public class CreateConfigCommandHandler : IRequestHandler<CreateConfigDto>
    {
        private readonly IConfigCommandService _configCommandService;
        private readonly IMapper _mapper;
        public CreateConfigCommandHandler(IConfigCommandService configCommandService, IMapper mapper)
        {
            _configCommandService = configCommandService;
            _configCommandService.NotNull(nameof(_configCommandService));

            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));
        }
        public async Task Handle(CreateConfigDto request, CancellationToken cancellationToken)
        {
            var config = _mapper.Map<Entities.Config>(request);
            await _configCommandService.Add(config);
        }
    }
}
