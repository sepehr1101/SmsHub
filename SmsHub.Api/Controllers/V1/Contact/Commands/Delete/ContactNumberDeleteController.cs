using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Contact.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Contact.Commands.Delete
{
    [Route(nameof(ContactNumber))]
    [ApiController]
    public class ContactNumberDeleteController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IContactNumberDeleteHandler _deleteCommandHandler;
        public ContactNumberDeleteController(
            IUnitOfWork uow, 
            IContactNumberDeleteHandler deleteCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _deleteCommandHandler = deleteCommandHandler;
            _deleteCommandHandler.NotNull(nameof(deleteCommandHandler));
        }

        [HttpPost]
        [Route(nameof(Delete))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<DeleteContactNumberDto>), StatusCodes.Status200OK)]

        public async Task<IActionResult> Delete([FromBody] DeleteContactNumberDto deleteDto, CancellationToken cancellationToken)
        {
            await _deleteCommandHandler.Handle(deleteDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(deleteDto);
        }
    }
}
