using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Consumer.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Consumer.Commands.Delete
{
    [Route(nameof(ConsumerLine))]
    [ApiController]
    public class ConsumerLineDeleteController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IConsumerLineDeleteHandler _deleteCommandHandler;
        public ConsumerLineDeleteController(
            IUnitOfWork uow, 
            IConsumerLineDeleteHandler deleteCommandHadler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _deleteCommandHandler = deleteCommandHadler;
            _deleteCommandHandler.NotNull(nameof(deleteCommandHadler));
        }

        [HttpPost]
        [Route(nameof(Delete))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<DeleteConsumerLineDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromBody] DeleteConsumerLineDto deleteDto, CancellationToken cancellationToken)
        {
            await _deleteCommandHandler.Handle(deleteDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(deleteDto);
        }
    }
}
