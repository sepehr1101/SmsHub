﻿using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.Config.Querries
{
    [Route(nameof(CcSend))]
    [ApiController]
    public class CcSendGetListController : ControllerBase
    {
        private readonly ICcSendGetListHandler _getListHandler;
        public CcSendGetListController(ICcSendGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<ICollection<GetCcSendDto>> GetList()
        {
            var ccSends = await _getListHandler.Handle();
            return ccSends;
        }
    }
}