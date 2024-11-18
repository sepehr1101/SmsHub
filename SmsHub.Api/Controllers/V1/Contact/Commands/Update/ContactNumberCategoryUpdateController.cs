using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Contact.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Contact.Commands.Update
{
    [Route(nameof(ContactNumberCategory))]
    [ApiController]
    public class ContactNumberCategoryUpdateController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IContactNumberCategoryUpdateHandler _updateCommandHandler;
        public ContactNumberCategoryUpdateController(IUnitOfWork uow, IContactNumberCategoryUpdateHandler updateCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _updateCommandHandler = updateCommandHandler;
            _updateCommandHandler.NotNull(nameof(updateCommandHandler));
        }

        [HttpPost]
        [Route(nameof(Update))]
        public async Task<IActionResult> Update([FromBody] UpdateContactNumberCategoryDto updateDto, CancellationToken cancellationToken)
        {
            await _updateCommandHandler.Handle(updateDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok();
        }
    }
}
