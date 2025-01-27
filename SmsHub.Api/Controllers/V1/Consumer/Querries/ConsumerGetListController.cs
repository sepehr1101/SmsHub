using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Consumer.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Queries;
using SmsHub.Persistence.Contexts.UnitOfWork;
using System.Threading;

namespace SmsHub.Api.Controllers.V1.Consumer.Querries
{
    [Route(nameof(Consumer))]
    [ApiController]
    public class ConsumerGetListController : BaseController
    {
        private readonly IConsumerGetListHandler _getListHandler; 
        private readonly IUnitOfWork _uow;

        public ConsumerGetListController(
            IConsumerGetListHandler getListHandler,
            IUnitOfWork uow)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));

            _uow = uow;
            _uow.NotNull(nameof(uow));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<GetConsumerDto>>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetList(CancellationToken cancellationToken)
        {
            var consumers = await _getListHandler.Handle();
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(consumers);
        }
    }
}
