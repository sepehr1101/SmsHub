using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Contact.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.V1.Contact.Querries
{
    [Route(nameof(Contact))]
    [ApiController]
    [Authorize]
    public class ContactGetListController : BaseController
    {
        private readonly IContactGetListHandler _getListHandler;
        public ContactGetListController(IContactGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }


        [HttpPost]
        [Route(nameof(GetList))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<GetContactDto>>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.SendConfigSection, LogLevelMessageResources.GetSumContactDescription)]
        public async Task<IActionResult> GetList()
        {
            var contacts = await _getListHandler.Handle();
            return Ok(contacts);
        }
    }
}
