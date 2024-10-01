using AutoMapper;
using SmsHub.Application.Features.Logging.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Logging.Queries.Contracts;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Update.Implementations
{
    public class UpdateDeepLogHandler: IUpdateDeepLogHandler
    {
        private readonly IMapper _mapper;
        private readonly IDeepLogQueryService _deepLogQueryService;
        public UpdateDeepLogHandler(IMapper mapper, IDeepLogQueryService deepLogQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _deepLogQueryService = deepLogQueryService;
            _deepLogQueryService.NotNull(nameof(deepLogQueryService));
        }
        public async Task Handle(UpdateDeepLogDto updateDeepLogDto, CancellationToken cancellationToken)
        {
            var deepLog=await _deepLogQueryService.Get(updateDeepLogDto.Id);
            _mapper.Map(updateDeepLogDto, deepLog);
        }
    }
}
