using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.V1.Config.Querries
{
    [Route(nameof(DisallowedPhrase))]
    [ApiController]
    public class DisallowedPhraseGetSingleController : BaseController
    {
        private readonly IDisallowedPhraseGetSingleHandler _getSingleHandler;
        public DisallowedPhraseGetSingleController(IDisallowedPhraseGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(_getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<GetDisallowedPhraseDto>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetSingle([FromBody] IntId Id)
        {
            var disallowedPhrase = await _getSingleHandler.Handle(Id);
            return Ok(disallowedPhrase);
        }

    }
}
