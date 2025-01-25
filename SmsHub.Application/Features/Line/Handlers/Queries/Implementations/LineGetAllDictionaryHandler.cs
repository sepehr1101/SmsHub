using SmsHub.Application.Features.Line.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Line.Queries.Contracts;

namespace SmsHub.Application.Features.Line.Handlers.Queries.Implementations
{
    public class LineGetAllDictionaryHandler : ILineGetAllDictionaryHandler
    {
        private readonly ILineQueryService _lineQueryService;
        public LineGetAllDictionaryHandler(ILineQueryService lineQueryService)
        {
            _lineQueryService = lineQueryService;
            _lineQueryService.NotNull(nameof(lineQueryService));
        }
        public async Task<ICollection<LineDictionary>> Handle()
        {
            var result = await _lineQueryService.GetLineDictionary();
            return result;
        }
    }
}
