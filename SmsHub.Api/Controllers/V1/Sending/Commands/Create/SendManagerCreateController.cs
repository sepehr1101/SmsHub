﻿using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Application.Features.Sending.Services;
using SmsHub.Application.Features.Sending.Services.Contracts;
using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Contexts.UnitOfWork;
using System.Threading;

namespace SmsHub.Api.Controllers.V1.Sending.Commands.Create
{
    [ApiController]
    [Route("Send")]
    public class SendManagerCreateController : BaseController
    {
        private readonly ITemplateGetSingleHandler _templateGetSingleHandler;
        private readonly IUnitOfWork _uow;
        private readonly ISendManagerCreateHandler _sendManagerCreateHandler;

        //todo delete
        private readonly ISmsClient _smsClient;

        public SendManagerCreateController(
            ITemplateGetSingleHandler templateGetSingleHandler,
            IUnitOfWork uow,
            ISendManagerCreateHandler sendManagerCreateHandler,
            ISmsClient smsClient)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _templateGetSingleHandler = templateGetSingleHandler;
            _templateGetSingleHandler.NotNull(nameof(templateGetSingleHandler));

            _sendManagerCreateHandler = sendManagerCreateHandler;
            _sendManagerCreateHandler.NotNull(nameof(sendManagerCreateHandler));

            _smsClient = smsClient;
            _smsClient.NotNull(nameof(smsClient));
        }

        [HttpPost]
        [Route("SendManager/{templateId}/{lineId}")]
        public async Task<IActionResult> SendManager(int templateId,int lineId,CancellationToken cancellationToken)
        {
           var messages= await _sendManagerCreateHandler.Handle(templateId,lineId ,new CancellationToken());
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(messages);
        }

        [HttpGet]
        [Route("Test/Kavenegar")]
        public async Task<IActionResult> TestKavenegar()
        {
            await _smsClient.SendKaveTest();
            return Ok("done");
        }
    }
}
