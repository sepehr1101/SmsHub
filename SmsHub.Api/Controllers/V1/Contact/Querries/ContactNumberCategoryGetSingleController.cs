using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Contact.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.V1.Contact.Querries
{
    [Route(nameof(ContactNumberCategory))]
    [ApiController]
    public class ContactNumberCategoryGetSingleController : BaseController
    {
        private readonly IContactNumberCategoryGetSingleHandler _getSingleHandler;
        public ContactNumberCategoryGetSingleController(IContactNumberCategoryGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<IActionResult> GetSingle([FromBody] IntId Id)
        {
            var contactNumberCategory = await _getSingleHandler.Handle(Id);
            return Ok(contactNumberCategory);
        }
    }
}
