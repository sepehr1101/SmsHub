using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Logging.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.V1.Logging.Querries
{
    [Route(nameof(DeepLog))]
    [ApiController]
    public class DeepLogGetSingleController : BaseController
    {
        private readonly IDeepLogGetSingleHandler _getSingleHandler;
        public DeepLogGetSingleController(IDeepLogGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<IActionResult> GetSingle([FromBody] IntId Id)
        {
            var deepLog = await _getSingleHandler.Handle(Id);
            return Ok(deepLog);
        }
    }
}
