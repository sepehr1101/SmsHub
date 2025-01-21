using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Common.Services.Implementations;
using SmsHub.Application.Exceptions;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Application.Features.Sending.Services.Contracts;
using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Sending.Entities;
using SmsHub.Domain.Providers.Kavenegar.Entities.Requests;
using SmsHub.Infrastructure.Providers.Kavenegar.Http.Contracts;
using SmsHub.Persistence.Contexts.UnitOfWork;
using Entities = SmsHub.Domain.Features.Entities;


namespace SmsHub.Api.Controllers.V1.Sending.Commands.Create
{
    [ApiController]
    [Route("Send")]
    public class SendManagerCreateController : BaseController
    {
        private readonly ITemplateGetSingleHandler _templateGetSingleHandler;
        private readonly IUnitOfWork _uow;
        private readonly ISendManagerCreateHandler _sendManagerCreateHandler;

        //remove
        private readonly ISmsProvider _smsProvider;
        private readonly IKavenegarHttpStatusService _statusService;


        public SendManagerCreateController(
                    ITemplateGetSingleHandler templateGetSingleHandler,
                    IUnitOfWork uow,
                    ISendManagerCreateHandler sendManagerCreateHandler,
                    ISmsProvider smsProvider,
                    IKavenegarHttpStatusService statusService)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _templateGetSingleHandler = templateGetSingleHandler;
            _templateGetSingleHandler.NotNull(nameof(templateGetSingleHandler));

            _sendManagerCreateHandler = sendManagerCreateHandler;
            _sendManagerCreateHandler.NotNull(nameof(sendManagerCreateHandler));

            _smsProvider=smsProvider; 
            _smsProvider.NotNull(nameof(_smsProvider));

            _statusService= statusService;
            _statusService.NotNull(nameof(_statusService));
        }

        [HttpPost]
        [Route("SendManager/{templateId}/{lineId}")]
        public async Task<IActionResult> SendManager(int templateId, int lineId, CancellationToken cancellationToken)
        {
            var messages = await _sendManagerCreateHandler.Handle(templateId, lineId, new CancellationToken());
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(messages);
        }


        
        //remove
        [HttpPost]
        [Route("Status/{ProviderId}/{IdToSearch}")]
        public async Task<IActionResult> Status(string ProviderId, int IdToSearch)
        {
             await GetState(ProviderId, IdToSearch);
            return Ok();

        }
        public async Task GetState(string line, long id)
        {
            var apiKey = line.ToString();

            StatusDto status = id;//1828205579
            var response = await _statusService.Trigger(status, apiKey);

        }
    }

}