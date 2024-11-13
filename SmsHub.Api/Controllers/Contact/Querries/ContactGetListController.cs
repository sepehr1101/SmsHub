using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Contact.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.Contact.Querries
{
    [Route(nameof(Contact))]
    [ApiController]
    public class ContactGetListController : ControllerBase
    {
        private readonly IContactGetListHandler _getListHandler;
        public ContactGetListController(IContactGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }


        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<ICollection<GetContactDto>> GetList()
        {
            var contacts = await _getListHandler.Handle();
            return contacts;
        }
    }
}
