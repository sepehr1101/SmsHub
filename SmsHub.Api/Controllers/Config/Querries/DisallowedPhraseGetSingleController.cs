using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.Config.Querries
{
    [Route(nameof(DisallowedPhrase))]
    [ApiController]
    public class DisallowedPhraseGetSingleController : Controller
    {
        private readonly IDisallowedPhraseGetSingleHandler _getSingleHandler;
        public DisallowedPhraseGetSingleController(IDisallowedPhraseGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(_getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<GetDisallowedPhraseDto> GetSingle([FromBody] IntId Id)
        {
            var disallowedPhrase=await _getSingleHandler.Handle(Id);
            return disallowedPhrase;
        }

    }
}
