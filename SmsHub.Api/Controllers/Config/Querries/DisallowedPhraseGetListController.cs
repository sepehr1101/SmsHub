using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.Config.Querries
{
    [Route(nameof(DisallowedPhrase))]
    [ApiController]
    public class DisallowedPhraseGetListController : Controller
    {
        private readonly IDisallowedPhraseGetListHandler _getListHandler;
        public DisallowedPhraseGetListController(IDisallowedPhraseGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<ICollection<GetDisallowedPhraseDto>> GetList()
        {
            var disallowedPhrases = await _getListHandler.Handle();
            return disallowedPhrases;
        }

    }
}
