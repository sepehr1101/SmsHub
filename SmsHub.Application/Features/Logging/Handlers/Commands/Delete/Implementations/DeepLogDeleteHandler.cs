using AutoMapper;
using SmsHub.Application.Features.Logging.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Logging.Commands.Contracts;
using SmsHub.Persistence.Features.Logging.Queries.Contracts;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Delete.Implementations
{
    public class DeepLogDeleteHandler: IDeepLogDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IDeepLogCommandService _deepLogCommandService;
        private readonly IDeepLogQueryService _deepLogQueryService;
        public DeepLogDeleteHandler(
            IMapper mapper, 
            IDeepLogCommandService deepLogCommandService,
            IDeepLogQueryService deepLogQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _deepLogCommandService = deepLogCommandService;
            _deepLogCommandService.NotNull(nameof(deepLogQueryService));

            _deepLogQueryService = deepLogQueryService;
            _deepLogQueryService.NotNull(nameof(deepLogQueryService));
        }
        public async Task Handle(DeleteDeepLogDto deleteDeepLogDto, CancellationToken cancellationToken)
        {
            var deepLog=await _deepLogQueryService.Get(deleteDeepLogDto.Id);
            _deepLogCommandService.Delete(deepLog);
        }
    }
}
