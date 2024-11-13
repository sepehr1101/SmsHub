using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Logging.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.Logging.Querries
{
    [Route(nameof(DeepLog))]
    [ApiController]
    public class DeepLogGetSingleController : ControllerBase
    {
        private readonly IDeepLogGetSingleHandler _getSingleHandler;
        public DeepLogGetSingleController(IDeepLogGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<GetDeepLogDto> GetSingle([FromBody] IntId Id)
        {
            var deepLog = await _getSingleHandler.Handle(Id);
            return deepLog;
        }
    }
}
