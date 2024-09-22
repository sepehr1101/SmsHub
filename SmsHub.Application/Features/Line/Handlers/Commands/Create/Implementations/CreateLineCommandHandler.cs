using AutoMapper;
using MediatR;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Line.Commands.Contracts;
using SmsHub.Application.Features.Line.Handlers.Commands.Create.Contracts;

namespace SmsHub.Application.Features.Line.Handlers.Commands.Create.Implementations
{
    public class CreateLineCommandHandler : /*IRequestHandler<CreateLineDto>,*/ ICreateLineCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly ILineCommandService _lineCommandService;
        public CreateLineCommandHandler(IMapper mapper, ILineCommandService lineCommandService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _lineCommandService = lineCommandService;
            _lineCommandService.NotNull(nameof(_lineCommandService));
        }

        public async Task Handle(CreateLineDto request, CancellationToken cancellationToken)
        {
            var line = _mapper.Map<Entities.Line>(request);
            await _lineCommandService.Add(line);
        }
    }
}
