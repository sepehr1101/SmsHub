using AutoMapper;
using MediatR;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Logging.Commands.Contracts;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Application.Features.Logging.Handlers.Commands.Create.Contracts;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Create.Implementations
{
    public class CreateDeepLogCommandHandler : ICreateDeepLogCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IDeepLogCommandService _deepLogCommandService;
        public CreateDeepLogCommandHandler(IMapper mapper, IDeepLogCommandService deepLogCommandService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _deepLogCommandService = deepLogCommandService;
            _deepLogCommandService.NotNull(nameof(_deepLogCommandService));
        }

        public async Task Handle(CreateDeepLogDto request, CancellationToken cancellationToken)
        {
            var deepLog = _mapper.Map<Entities.DeepLog>(request);
            await _deepLogCommandService.Add(deepLog);
        }
    }
}
