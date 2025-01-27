using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Commands.Create.Contracts;
using SmsHub.Application.Features.Logging.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Config.Commands.Create
{
    [Route("cc-send")]
    [ApiController]
    public class CcSendCreateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly ICcSendCreateHandler _createCommandHandler;
        private readonly IInformativeLogCreateHandler _informativeLogCreateHandler;
        public CcSendCreateController(
            IUnitOfWork uow,
            ICcSendCreateHandler createCommandHandler,
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
        [Route("create")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<CreateCcSendDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] CreateCcSendDto createDto, CancellationToken cancellationToken)
        {
            await _createCommandHandler.Handle(createDto, cancellationToken);
            
            //add InformativeLog
            var informativeLog = new CreateInformativeLogDto()// *** UserID;
            {
                   LogLevelId=LogLevelEnum.InternalOperation,
                   Section=LogLevelMessageResources.SendConfigSection,
                   Description=LogLevelMessageResources.AddCcSendDescription,
                   UserId= new Guid(),//userId
                   UserInfo=" "
            };
            await _informativeLogCreateHandler.Handle(informativeLog, cancellationToken);

            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(createDto);
        }
    }
}