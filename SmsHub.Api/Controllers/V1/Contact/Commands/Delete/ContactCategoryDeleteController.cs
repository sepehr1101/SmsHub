using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Contact.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Contact.Commands.Delete
{
    [Route(nameof(ContactCategory))]
    [ApiController]
    [Authorize]
    public class ContactCategoryDeleteController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IContactCategoryDeleteHandler _deleteCommandHandler;
        public ContactCategoryDeleteController(
            IUnitOfWork uow,
            IContactCategoryDeleteHandler deleteCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _deleteCommandHandler = deleteCommandHandler;
            _deleteCommandHandler.NotNull(nameof(deleteCommandHandler));
        }

        [HttpPost]
        [Route(nameof(Delete))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<DeleteContactCategoryDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.ContactSection, LogLevelMessageResources.ContactCategory + LogLevelMessageResources.DeleteDescription)]
        public async Task<IActionResult> Delete([FromBody] DeleteContactCategoryDto deleteDto, CancellationToken cancellationToken)
        {
            await _deleteCommandHandler.Handle(deleteDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(deleteDto);
        }
    }
}
