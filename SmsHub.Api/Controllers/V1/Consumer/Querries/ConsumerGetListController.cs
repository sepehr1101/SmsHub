﻿using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Consumer.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.V1.Consumer.Querries
{
    [Route(nameof(Consumer))]
    [ApiController]
    public class ConsumerGetListController : BaseController
    {
        private readonly IConsumerGetListHandler _getListHandler;
        public ConsumerGetListController(IConsumerGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<ICollection<GetConsumerDto>> GetList()
        {
            var consumers = await _getListHandler.Handle();
            return consumers;
        }
    }
}