﻿using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Logging.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.Logging.Commands.Create
{
    [Route("api/OperationType")]
    [ApiController]
    public class OperationTypeCreateController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly ICreateOperationTypeCommandHandler _createCommandHandler;
        public OperationTypeCreateController(IUnitOfWork uow, ICreateOperationTypeCommandHandler createCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _createCommandHandler = createCommandHandler;
            _createCommandHandler.NotNull(nameof(createCommandHandler));
        }
        [HttpGet(Name = nameof(Create))]
        public async Task<IActionResult> Create([FromBody] CreateOperationTypeDto createDto, CancellationToken cancellationToken)
        {
            await _createCommandHandler.Handle(createDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok();
        }
    }
}