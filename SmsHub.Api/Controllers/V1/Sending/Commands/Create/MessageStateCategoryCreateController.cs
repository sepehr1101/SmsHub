using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Line.Handlers.Queries.Contracts;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Line.Queries.Contracts;
using SmsHub.Persistence.Features.Line.Queries.Implementations;

namespace SmsHub.Api.Controllers.V1.Sending.Commands.Create
{
    [Route(nameof(MessageStateCategory))]
    [ApiController]
    [Authorize]
    public class MessageStateCategoryCreateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IMessageStateCategoryCreateHandler _createCommandHandler;
        private readonly IProviderGetSingleHandler _providerGetSingleHandler;
        public MessageStateCategoryCreateController(
            IUnitOfWork uow, 
            IMessageStateCategoryCreateHandler createCommandHandler,
            IProviderGetSingleHandler providerGetSingleHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _createCommandHandler = createCommandHandler;
            _createCommandHandler.NotNull(nameof(createCommandHandler));

            _providerGetSingleHandler = providerGetSingleHandler;   
            _providerGetSingleHandler   .NotNull(nameof(providerGetSingleHandler));
        }

        [HttpPost]
        [Route(nameof(Create))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<CreateMessageStateCategoryDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.SendSection, LogLevelMessageResources.MessageStateCategory + LogLevelMessageResources.AddDescription)]
        public async Task<IActionResult> Create([FromBody] CreateMessageStateCategoryDto createDto, CancellationToken cancellationToken)
        {
            var provider=await _providerGetSingleHandler.Handle(createDto.ProviderId);

            await _createCommandHandler.Handle(createDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(createDto);
        }
    }
}
