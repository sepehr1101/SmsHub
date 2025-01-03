﻿using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Sending.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Sending.Commands.Delete
{
    [Route(nameof(MessagesDetail))]
    [ApiController]
    public class MessageDetailDeleteController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IMessageDetailDeleteHandler _deleteCommandHandler;
        public MessageDetailDeleteController(
            IUnitOfWork uow,
            IMessageDetailDeleteHandler deleteCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _deleteCommandHandler = deleteCommandHandler;
            _deleteCommandHandler.NotNull(nameof(deleteCommandHandler));
        }

        [HttpPost]
        [Route(nameof(Delete))]
        public async Task<IActionResult> Delete([FromBody] DeleteMessageDetailDto deleteDto, CancellationToken cancellationToken)
        {
            await _deleteCommandHandler.Handle(deleteDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(deleteDto);
        }
    }
}
