﻿using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Consumer.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.Consumer.Commands.Create
{
    [Route("api/ConsumerSafeIp")]
    [ApiController]
    public class ConsumerSafeIpCreateController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly ICreateConsumeSafeIprCommandHandler _createCommandHandler;
        public ConsumerSafeIpCreateController(IUnitOfWork uow, ICreateConsumeSafeIprCommandHandler createCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _createCommandHandler = createCommandHandler;
            _createCommandHandler.NotNull(nameof(createCommandHandler));
        }
        [HttpGet(Name = nameof(Create))]
        public async Task<IActionResult> Create([FromBody] CreateConsumerSafeIpDto createDto, CancellationToken cancellationToken)
        {
            await _createCommandHandler.Handle(createDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok();
        }
    }
}