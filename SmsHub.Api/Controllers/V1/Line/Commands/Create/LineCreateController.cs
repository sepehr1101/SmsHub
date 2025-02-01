using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Line.Handlers.Commands.Create.Contracts;
using SmsHub.Application.Features.Line.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Line.Commands.Create
{
    [Route("line")]
    [ApiController]
    [Authorize]
    public class LineCreateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly ILineCreateHandler _createCommandHandler;
        private readonly IProviderGetSingleHandler _providerGetSingleHandler;
        public LineCreateController(
            IUnitOfWork uow,
            ILineCreateHandler createCommandHandler,
            IProviderGetSingleHandler providerGetSingleHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _createCommandHandler = createCommandHandler;
            _createCommandHandler.NotNull(nameof(_createCommandHandler));

            _providerGetSingleHandler = providerGetSingleHandler;
            _providerGetSingleHandler.NotNull(nameof(_providerGetSingleHandler));
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<GetLineDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.LineSection, LogLevelMessageResources.Line + LogLevelMessageResources.AddDescription)]
        public async Task<IActionResult> Create([FromBody] CreateLineDto createDto, CancellationToken cancellationToken)
        {
            var provider = await _providerGetSingleHandler.Handle(createDto.ProviderId);

            await _createCommandHandler.Handle(createDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(createDto);
        }


    }
}
