﻿using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Consumer.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Consumer.Commands.Delete
{
    [Route(nameof(ConsumerSafeIp))]
    [ApiController]
    public class ConsumerSafeIpDeleteController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IConsumerSafeIpDeleteHandler _deleteCommandHandler;
        public ConsumerSafeIpDeleteController(
            IUnitOfWork uow, 
            IConsumerSafeIpDeleteHandler deleteCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _deleteCommandHandler = deleteCommandHandler;
            _deleteCommandHandler.NotNull(nameof(deleteCommandHandler));
        }

        [HttpPost]
        [HttpPost(nameof(Delete))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<DeleteConsumerSafeIpDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromBody] DeleteConsumerSafeIpDto deleteDto, CancellationToken cancellationToken)
        {
            await _deleteCommandHandler.Handle(deleteDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(deleteDto);
        }
    }
}
