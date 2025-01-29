using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Line.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Line.Queries
{
    [Route("line")]
    [ApiController]
    [Authorize]
    public class LineGetDictionaryController : BaseController
    {
        private readonly ILineGetAllDictionaryHandler _getLineDictionary; 
        private readonly IUnitOfWork _uow;

        public LineGetDictionaryController(ILineGetAllDictionaryHandler getLineDictionary,
            IUnitOfWork uow)
        {
            _getLineDictionary = getLineDictionary;
            _getLineDictionary.NotNull(nameof(getLineDictionary));

            _uow = uow;
            _uow.NotNull(nameof(uow));
        }

        [HttpGet]
        [Route("dictionary")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<LineDictionary>>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.LineSection, LogLevelMessageResources.Line + LogLevelMessageResources.GetDescription)]
        public async Task<IActionResult> Dictionary(CancellationToken cancellationToken)
        {
            var result = await _getLineDictionary.Handle();
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(result);
        }
    }
}
