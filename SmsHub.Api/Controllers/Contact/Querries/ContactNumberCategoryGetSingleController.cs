using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Contact.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.Contact.Querries
{
    [Route(nameof(ContactNumberCategory))]
    [ApiController]
    public class ContactNumberCategoryGetSingleController : ControllerBase
    {
        private readonly IContactNumberCategoryGetSingleHandler _getSingleHandler;
        public ContactNumberCategoryGetSingleController(IContactNumberCategoryGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<GetContactNumberCategoryDto> GetSingle([FromBody] IntId Id)
        {
            var contactNumberCategory = await _getSingleHandler.Handle(Id);
            return contactNumberCategory;
        }
    }
}
