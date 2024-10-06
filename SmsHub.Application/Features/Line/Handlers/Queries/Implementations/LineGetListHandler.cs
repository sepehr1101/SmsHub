using AutoMapper;
using SmsHub.Application.Features.Line.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Line.Queries.Contracts;

namespace SmsHub.Application.Features.Line.Handlers.Queries.Implementations
{
    public class LineGetListHandler: ILineGetListHandler
    {
        private readonly IMapper _mapper;
        private readonly ILineQueryService _lineQueryService;
        public LineGetListHandler(IMapper mapper, ILineQueryService lineQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _lineQueryService = lineQueryService;
            _lineQueryService.NotNull(nameof(lineQueryService));
        }
        public async Task<ICollection<GetLineDto>> Handle()
        {
            var lines = await _lineQueryService.Get();
            return _mapper.Map<ICollection<GetLineDto>>(lines);  
        }
    }
}
