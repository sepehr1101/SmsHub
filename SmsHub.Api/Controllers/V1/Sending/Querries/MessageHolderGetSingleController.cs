﻿using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.V1.Sending.Querries
{
    [Route(nameof(MessagesHolder))]
    [ApiController]
    public class MessageHolderGetSingleController : BaseController
    {
        private readonly IMessageHolderGetSingleHandler _getSingleHolder;
        public MessageHolderGetSingleController(IMessageHolderGetSingleHandler getSingleHolder)
        {
            _getSingleHolder = getSingleHolder;
            _getSingleHolder.NotNull(nameof(getSingleHolder));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<IActionResult> GetSingle([FromBody] GuidId Id)
        {
            var messageHolder = await _getSingleHolder.Handle(Id);
            return Ok(messageHolder);
        }
    }
}
