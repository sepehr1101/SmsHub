﻿using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Contact.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.Contact.Commands.Update
{
    [Route("api/ContactCategory")]
    [ApiController]
    public class ContactCategoryUpdateController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IUpdateContactCategoryHandler _updateCommandHandler;
        public ContactCategoryUpdateController(IUnitOfWork uow, IUpdateContactCategoryHandler updateCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _updateCommandHandler = updateCommandHandler;
            _updateCommandHandler.NotNull(nameof(updateCommandHandler));
        }
        [HttpGet(Name = nameof(Update))]
        public async Task<IActionResult> Update([FromBody] UpdateContactCategoryDto updateDto, CancellationToken cancellationToken)
        {
            await _updateCommandHandler.Handle(updateDto,cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok();
        }
    }
}