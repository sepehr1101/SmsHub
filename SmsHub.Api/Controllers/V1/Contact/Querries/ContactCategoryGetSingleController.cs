using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Contact.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.V1.Contact.Querries
{
    [Route(nameof(ContactCategory))]
    [ApiController]
    [Authorize]
    public class ContactCategoryGetSingleController : BaseController
    {
        private readonly IContactCategoryGetSingleHandler _getSingleHandler;
        public ContactCategoryGetSingleController(IContactCategoryGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<GetContactCategoryDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.SendConfigSection, LogLevelMessageResources.GetOneContactCategoryDescription)]
        public async Task<IActionResult> GetSingle([FromBody] IntId Id)
        {
            var contactCategory = await _getSingleHandler.Handle(Id);
            return Ok(contactCategory);
        }
    }
}
