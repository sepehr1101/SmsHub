using AutoMapper;
using SmsHub.Application.Features.Logging.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Logging.Queries.Contracts;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Update.Implementations
{
    public class InformativeLogUpdateHandler: IInformativeLogUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IInformativeLogQueryService _informativeLogQueryService;
        public InformativeLogUpdateHandler(IMapper mapper, IInformativeLogQueryService informativeLogQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _informativeLogQueryService = informativeLogQueryService;
            _informativeLogQueryService.NotNull(nameof(informativeLogQueryService));
        }
        public async Task Handle(UpdateInformativeLogDto updateInformativeLogDto, CancellationToken cancellationToken)
        {
            var informativeLog=await _informativeLogQueryService.Get(updateInformativeLogDto.Id);
            _mapper.Map(updateInformativeLogDto, informativeLog);
        }
    }
}
