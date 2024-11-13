using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Contact.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.Contact.Querries
{
    [Route(nameof(ContactCategory))]
    [ApiController]
    public class ContactCategoryGetListController : ControllerBase
    {
        private readonly IContactCategoryGetListHandler _getListHandler;
        public ContactCategoryGetListController(IContactCategoryGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<ICollection<GetContactCategoryDto>> GetList()
        {
            var contactCategories = await _getListHandler.Handle();
            return contactCategories;
        }
    }
}
