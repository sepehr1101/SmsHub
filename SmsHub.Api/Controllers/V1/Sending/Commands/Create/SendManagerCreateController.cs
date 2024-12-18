using Aban360.Api.Controllers.V1;
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
        public async Task<IActionResult> SendManager(int templateId, int lineId, CancellationToken cancellationToken)
        {
            var messages = await _sendManagerCreateHandler.Handle(templateId, lineId, new CancellationToken());
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(messages);
        }


        [HttpGet]
        [Route("Test/KavenegarAcount")]
        public async Task<IActionResult> TestKavenegarAcount()
        {
            await _smsClient.AcountKaveTest();
            return Ok("done");
        }


        [HttpGet]
        [Route("Test/KavenegarCancel")]
        public async Task<IActionResult> TestKavenegarCancel()
        {
            await _smsClient.CancelKaveTest();
            return Ok("done");
        }

        [HttpGet]
        [Route("Test/KavenegarCountInBox")]
        public async Task<IActionResult> TestKavenegarCountInBox()
        {
            await _smsClient.CountInBoxKaveTest();
            return Ok("done");
        }


        [HttpGet]
        [Route("Test/KavenegarDate")]
        public async Task<IActionResult> TestKavenegarDate()
        {
            await _smsClient.DateKaveTest();
            return Ok("done");
        }


        [HttpGet]
        [Route("Test/KavenegarLatestOutbox")]
        public async Task<IActionResult> TestKavenegarLatestOutbox()
        {
            await _smsClient.LatestOutboxKaveTest();
            return Ok("done");
        }


        [HttpGet]
        [Route("Test/KavenegarLookup")]
        public async Task<IActionResult> TestKavenegarLookup()
        {
            await _smsClient.LookupKaveTest();
            return Ok("done");
        }


        [HttpGet]
        [Route("Test/KavenegarMaketts")]
        public async Task<IActionResult> TestKavenegarMaketts()
        {
            await _smsClient.MakettsKaveTest();
            return Ok("done");
        }


        [HttpGet]
        [Route("Test/KavenegarReceive")]
        public async Task<IActionResult> TestKavenegarReceive()
        {
            await _smsClient.ReceiveKaveTest();
            return Ok("done");
        }



        [HttpGet]
        [Route("Test/KavenegarSelectOutbox")]
        public async Task<IActionResult> TestKavenegarSelectOutbox()
        {
            await _smsClient.SelectOutboxKaveTest();
            return Ok("done");
        }



        [HttpGet]
        [Route("Test/KavenegarSelect")]
        public async Task<IActionResult> TestKavenegarSelect()
        {
            await _smsClient.SelectKaveTest();
            return Ok("done");
        }


        [HttpGet]
        [Route("Test/KavenegarSendArray")]
        public async Task<IActionResult> TestKavenegarSendArray()
        {
            await _smsClient.SendArrayKeveTest();
            return Ok("done");
        }


        [HttpGet]
        [Route("Test/KavenegarSendSimple")]
        public async Task<IActionResult> TestKavenegarSendSimple()
        {
            await _smsClient.SendSimpleKaveTest();
            return Ok("done");
        }


        [HttpGet]
        [Route("Test/KavenegarStatusByMessage")]
        public async Task<IActionResult> TestKavenegarStatusByMessage()
        {
            await _smsClient.StatusByMessageKaveTest();
            return Ok("done");
        }


        [HttpGet]
        [Route("Test/KavenegarStatus")]
        public async Task<IActionResult> TestKavenegarStatus()
        {
            await _smsClient.StatusKaveTest();
            return Ok("done");
        }

        ///////////////////////////////////////////
        ///Magfa

    }
}
