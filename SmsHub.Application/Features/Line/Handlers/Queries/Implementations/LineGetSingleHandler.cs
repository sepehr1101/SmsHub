using AutoMapper;
using SmsHub.Application.Features.Line.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Line.Queries.Contracts;

namespace SmsHub.Application.Features.Line.Handlers.Queries.Implementations
{
    public class LineGetSingleHandler: ILineGetSingleHandler
    {
        private readonly IMapper _mapper;
        private readonly ILineQueryService _lineQueryService;
        public LineGetSingleHandler(IMapper mapper, ILineQueryService lineQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _lineQueryService = lineQueryService;
            _lineQueryService.NotNull(nameof(lineQueryService));
        }
        public async Task<GetLineDto> Handle(IntId Id)
        {
            var line = await _lineQueryService.Get(Id.Id);
            return _mapper.Map<GetLineDto>(line);
        }
    }
}