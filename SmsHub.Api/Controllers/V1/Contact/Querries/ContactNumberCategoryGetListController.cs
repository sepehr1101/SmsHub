using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Contact.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.V1.Contact.Querries
{
    [Route(nameof(ContactNumberCategory))]
    [ApiController]
    public class ContactNumberCategoryGetListController : ControllerBase
    {
        private readonly IContactNumberCategoryGetListHandler _getListHandler;
        public ContactNumberCategoryGetListController(IContactNumberCategoryGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<ICollection<GetContactNumberCategoryDto>> GetList()
        {
            var contactNumberCategories = await _getListHandler.Handle();
            return contactNumberCategories;
        }
    }
}
