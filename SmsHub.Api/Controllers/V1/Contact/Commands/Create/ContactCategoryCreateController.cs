using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Contact.Handlers.Commands.Create.Contracts;
using SmsHub.Application.Features.Logging.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Contact.Commands.Create
{
    [Route(nameof(ContactCategory))]
    [ApiController]
    [Authorize]
    public class ContactCategoryCreateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IContactCategoryCreateHandler _createCommandHandler;
        private readonly IInformativeLogCreateHandler _informativeLogCreateHandler;

        public ContactCategoryCreateController(
            IUnitOfWork uow,
            IContactCategoryCreateHandler createCommandHandler,
             IInformativeLogCreateHandler informativeLogCreateHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _createCommandHandler = createCommandHandler;
            _createCommandHandler.NotNull(nameof(createCommandHandler));

            _informativeLogCreateHandler = informativeLogCreateHandler;
            _informativeLogCreateHandler.NotNull(nameof(informativeLogCreateHandler));
        }

        [HttpPost]
        [Route(nameof(Create))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<CreateContactCategoryDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.ContactSection, LogLevelMessageResources.ContactCategory + LogLevelMessageResources.AddDescription)]
        public async Task<IActionResult> Create([FromBody] CreateContactCategoryDto createDto, CancellationToken cancellationToken)
        {
            await _createCommandHandler.Handle(createDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(createDto);
        }
    }
}
