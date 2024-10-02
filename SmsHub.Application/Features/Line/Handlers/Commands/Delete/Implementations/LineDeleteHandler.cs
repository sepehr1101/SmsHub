using AutoMapper;
using SmsHub.Application.Features.Line.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Line.Commands.Contracts;
using SmsHub.Persistence.Features.Line.Queries.Contracts;

namespace SmsHub.Application.Features.Line.Handlers.Commands.Delete.Implementations
{
    public class LineDeleteHandler: ILineDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly ILineCommandService _lineCommandService;
        private readonly ILineQueryService _lineQueryService;
        public LineDeleteHandler(
            IMapper mapper, 
            ILineCommandService lineCommandService, 
            ILineQueryService lineQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _lineCommandService = lineCommandService;
            _lineCommandService.NotNull(nameof(lineCommandService));

            _lineQueryService = lineQueryService;
            _lineQueryService.NotNull(nameof(lineQueryService));
        }
        public async Task Handle(DeleteLineDto deleteLineDto, CancellationToken cancellationToken)
        {
            var line = await _lineQueryService.Get(deleteLineDto.Id);
            _lineCommandService.Delete(line);
        }
    }
}
