﻿using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Contact.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.Contact.Commands.Delete
{
    [Route("api/ContactCategory")]
    [ApiController]
    public class ContactCategoryDeleteController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IContactCategoryDeleteHandler _deleteCommandHandler;
        public ContactCategoryDeleteController(IUnitOfWork uow, IContactCategoryDeleteHandler deleteCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _deleteCommandHandler = deleteCommandHandler;
            _deleteCommandHandler.NotNull(nameof(deleteCommandHandler));
        }
        [HttpGet(Name = nameof(Delete))]
        public async Task<IActionResult> Delete([FromBody] DeleteContactCategoryDto deleteDto, CancellationToken cancellationToken)
        {
            await _deleteCommandHandler.Handle(deleteDto,cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok();
        }
    }
}