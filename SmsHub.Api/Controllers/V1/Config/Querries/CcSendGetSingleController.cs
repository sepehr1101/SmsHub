using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Config.Querries
{
    [Route(nameof(CcSend))]
    [ApiController]
    public class CcSendGetSingleController : ControllerBase
    {
        private readonly ICcSendGetSingleHandler _getSingleHandler;
        public CcSendGetSingleController(ICcSendGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<GetCcSendDto> GetSingle([FromBody] IntId Id)
        {
            var ccSend = await _getSingleHandler.Handle(Id);
            return ccSend;
        }
    }
}
