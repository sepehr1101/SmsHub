using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Logging.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.Logging.Querries
{
    [Route(nameof(InformativeLog))]
    [ApiController]
    public class InformativeLogGetSingleController : ControllerBase
    {
        private readonly IInformativeLogGetSingleHandler _getSingleHandler;
        public InformativeLogGetSingleController(IInformativeLogGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<GetInforamtaiveLogDto> GetSingle([FromBody] IntId Id)
        {
            var informativeLog = await _getSingleHandler.Handle(Id);
            return informativeLog;
        }
    }
}
