using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Contact.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.Contact.Querries
{
    [Route(nameof(ContactNumber))]
    [ApiController]
    public class ContactNumberGetSingleController : ControllerBase
    {
        private readonly IContactNumberGetSingleHandler _getSingleHandle;
        public ContactNumberGetSingleController(IContactNumberGetSingleHandler getSingleHandler)
        {
            _getSingleHandle= getSingleHandler;
            _getSingleHandle.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<GetContactNumberDto> GetSingle([FromBody] IntId Id)
        {
            var contactNumber=await _getSingleHandle.Handle(Id);
            return contactNumber;
        }
    }
}
