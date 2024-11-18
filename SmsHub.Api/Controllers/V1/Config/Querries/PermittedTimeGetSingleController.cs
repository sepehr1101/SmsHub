using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.V1.Config.Querries
{
    [Route(nameof(PermittedTime))]
    [ApiController]
    public class PermittedTimeGetSingleController : BaseController
    {
        private readonly IPermittedTimeGetSingleHandler _getSingleHandler;
        public PermittedTimeGetSingleController(IPermittedTimeGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<GetPermittedTimeDto> GetSingle([FromBody] IntId Id)
        {
            var permittedTime = await _getSingleHandler.Handle(Id);
            return permittedTime;
        }
    }
}
