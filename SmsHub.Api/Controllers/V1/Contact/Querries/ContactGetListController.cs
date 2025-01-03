﻿using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Contact.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;

namespace SmsHub.Api.Controllers.V1.Contact.Querries
{
    [Route(nameof(Contact))]
    [ApiController]
    public class ContactGetListController : BaseController
    {
        private readonly IContactGetListHandler _getListHandler;
        public ContactGetListController(IContactGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }


        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<IActionResult> GetList()
        {
            var contacts = await _getListHandler.Handle();
            return Ok(contacts);
        }
    }
}
