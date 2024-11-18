using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Contact.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.V1.Contact.Querries
{
    [Route(nameof(Contact))]
    [ApiController]
    public class ContactGetSingleController : ControllerBase
    {
        private readonly IContactGetSingleHandler _getListHandler;
        public ContactGetSingleController(IContactGetSingleHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<GetContactDto> GetSingle([FromBody] IntId Id)
        {
            var contact = await _getListHandler.Handle(Id);
            return contact;
        }
    }
}
