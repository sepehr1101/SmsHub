using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Line.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Line.Queries.Contracts;

namespace SmsHub.Api.Controllers.V1.Line.Queries
{
    [Route("line")]
    [ApiController]
    public class LineGetDictionaryController : BaseController
    {
        private readonly ILineGetAllDictionaryHandler _getLineDictionary;
        public LineGetDictionaryController(ILineGetAllDictionaryHandler getLineDictionary)
        {
            _getLineDictionary = getLineDictionary;
            _getLineDictionary.NotNull(nameof(getLineDictionary));
        }

        [HttpGet]
        [Route("dictionary")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<LineDictionary>>), StatusCodes.Status200OK)]

        public async Task<IActionResult> Dictionary()
        {
            var result = await _getLineDictionary.Handle();

            return Ok(result);
        }
    }
}
