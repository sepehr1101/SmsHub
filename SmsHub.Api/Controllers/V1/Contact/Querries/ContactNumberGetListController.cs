using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Contact.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.V1.Contact.Querries
{
    [Route(nameof(ContactNumber))]
    [ApiController]
    public class ContactNumberGetListController : BaseController
    {
        private readonly IContactNumberGetListHandler _getListHandler;
        public ContactNumberGetListController(IContactNumberGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<IActionResult> GetList()
        {
            var contactNumbers = await _getListHandler.Handle();
            return Ok(contactNumbers);
        }
    }
}
