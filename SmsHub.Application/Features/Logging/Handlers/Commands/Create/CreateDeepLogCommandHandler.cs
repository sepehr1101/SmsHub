using AutoMapper;
using MediatR;
using SmsHub.Common.Extensions;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Logging.Commands.Contracts;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Create
{
    public class CreateDeepLogCommandHandler:IRequestHandler<CreateDeepLogDto>
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
            var deepLog=_mapper.Map<Entities.DeepLog>(request);
            await _deepLogCommandService.Add(deepLog);
        }
    }
}
