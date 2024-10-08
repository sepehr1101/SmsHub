using AutoMapper;
using SmsHub.Application.Features.Line.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Update;
using SmsHub.Persistence.Features.Line.Queries.Contracts;

namespace SmsHub.Application.Features.Line.Handlers.Commands.Update.Implementations
{
    public class LineUpdateHandler: ILineUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly ILineQueryService _lineQueryService;
        public LineUpdateHandler(
            IMapper mapper,
            ILineQueryService lineQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _lineQueryService = lineQueryService;
            _lineQueryService.NotNull(nameof(lineQueryService));
        }
        public async Task Handle(UpdateLineDto updateLineDto, CancellationToken cancellationToken)
        {
            var line = await _lineQueryService.Get(updateLineDto.Id);
            _mapper.Map(updateLineDto, line);
        }
    }
}
