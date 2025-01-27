using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Contact.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.V1.Contact.Querries
{
    [Route(nameof(ContactCategory))]
    [ApiController]
    [Authorize]
    public class ContactCategoryGetListController : BaseController
    {
        private readonly IContactCategoryGetListHandler _getListHandler;
        public ContactCategoryGetListController(IContactCategoryGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<GetContactCategoryDto>>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.SendConfigSection, LogLevelMessageResources.GetSumContactCategoryDescription)]
        public async Task<IActionResult> GetList()
        {
            var contactCategories = await _getListHandler.Handle();
            return Ok(contactCategories);
        }
    }
}
