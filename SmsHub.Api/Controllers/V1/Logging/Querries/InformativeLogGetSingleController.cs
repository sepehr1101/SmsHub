using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Logging.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.V1.Logging.Querries
{
    [Route(nameof(InformativeLog))]
    [ApiController]
    public class InformativeLogGetSingleController : BaseController
    {
        private readonly IInformativeLogGetSingleHandler _getSingleHandler;
        public InformativeLogGetSingleController(IInformativeLogGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<IActionResult> GetSingle([FromBody] IntId Id)
        {
            var informativeLog = await _getSingleHandler.Handle(Id);
            return Ok(informativeLog);
        }
    }
}
