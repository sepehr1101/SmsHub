﻿using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Contact.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.V1.Contact.Querries
{
    [Route(nameof(ContactCategory))]
    [ApiController]
    public class ContactCategoryGetListController : BaseController
    {
        private readonly IContactCategoryGetListHandler _getListHandler;
        public ContactCategoryGetListController(IContactCategoryGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<IActionResult> GetList()
        {
            var contactCategories = await _getListHandler.Handle();
            return Ok(contactCategories);
        }
    }
}
