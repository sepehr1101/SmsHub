using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Contact.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.Contact.Querries
{
    [Route(nameof(ContactNumber))]
    [ApiController]
    public class ContactNumberGetListController : ControllerBase
    {
        private readonly IContactNumberGetListHandler _getListHandler;
        public ContactNumberGetListController(IContactNumberGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<ICollection<GetContactNumberDto>> GetList()
        {
            var contactNumbers = await _getListHandler.Handle();
            return contactNumbers;
        }
    }
}
