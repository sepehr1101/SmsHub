using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Contact.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.V1.Contact.Querries
{
    [Route(nameof(ContactCategory))]
    [ApiController]
    public class ContactCategoryGetSingleController : ControllerBase
    {
        private readonly IContactCategoryGetSingleHandler _getSingleHandler;
        public ContactCategoryGetSingleController(IContactCategoryGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<GetContactCategoryDto> GetSingle([FromBody] IntId Id)
        {
            var contactCategory = await _getSingleHandler.Handle(Id);
            return contactCategory;
        }
    }
}
