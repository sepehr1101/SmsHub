using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Application.Features.Sending.Services.Contracts;
using SmsHub.Application.Features.Sending.ServicesSample.Contracts;
using SmsHub.Application.Features.Sending.ServicesSample.Implementations;
using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;
using SmsHub.Persistence.Contexts.UnitOfWork;

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
        private readonly ISmsClientKevenegar _smsClientKavenagar;
        private readonly ISmsClientMagfa _smsClientMagfa;

        private readonly ISwitchingFactory _switchingFactory;

public SendManagerCreateController(
            ITemplateGetSingleHandler templateGetSingleHandler,
            IUnitOfWork uow,
            ISendManagerCreateHandler sendManagerCreateHandler,
            ISmsClientKevenegar smsClientKavenagar,
            ISmsClientMagfa smsClientMagfa,
            ISwitchingFactory switchingFactory)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _templateGetSingleHandler = templateGetSingleHandler;
            _templateGetSingleHandler.NotNull(nameof(templateGetSingleHandler));

            _sendManagerCreateHandler = sendManagerCreateHandler;
            _sendManagerCreateHandler.NotNull(nameof(sendManagerCreateHandler));

            _smsClientKavenagar = smsClientKavenagar;
            _smsClientKavenagar.NotNull(nameof(smsClientKavenagar));

            _smsClientMagfa = smsClientMagfa;
            _smsClientMagfa.NotNull(nameof(smsClientMagfa));

            _switchingFactory = switchingFactory;
            _switchingFactory.NotNull(nameof(switchingFactory));
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
            await _smsClientKavenagar.AcountKaveTest();
            return Ok("done");
        }


        [HttpGet]
        [Route("Test/KavenegarCancel")]
        public async Task<IActionResult> TestKavenegarCancel()
        {
            await _smsClientKavenagar.CancelKaveTest();
            return Ok("done");
        }

        [HttpGet]
        [Route("Test/KavenegarCountInBox")]
        public async Task<IActionResult> TestKavenegarCountInBox()
        {
            await _smsClientKavenagar.CountInBoxKaveTest();
            return Ok("done");
        }


        [HttpGet]
        [Route("Test/KavenegarDate")]
        public async Task<IActionResult> TestKavenegarDate()
        {
            await _smsClientKavenagar.DateKaveTest();
            return Ok("done");
        }


        [HttpGet]
        [Route("Test/KavenegarLatestOutbox")]
        public async Task<IActionResult> TestKavenegarLatestOutbox()
        {
            await _smsClientKavenagar.LatestOutboxKaveTest();
            return Ok("done");
        }


        [HttpGet]
        [Route("Test/KavenegarLookup")]
        public async Task<IActionResult> TestKavenegarLookup()
        {
            await _smsClientKavenagar.LookupKaveTest();
            return Ok("done");
        }


        [HttpGet]
        [Route("Test/KavenegarMaketts")]
        public async Task<IActionResult> TestKavenegarMaketts()
        {
            await _smsClientKavenagar.MakettsKaveTest();
            return Ok("done");
        }


        [HttpGet]
        [Route("Test/KavenegarReceive")]
        public async Task<IActionResult> TestKavenegarReceive()
        {
            await _smsClientKavenagar.ReceiveKaveTest();
            return Ok("done");
        }



        [HttpGet]
        [Route("Test/KavenegarSelectOutbox")]
        public async Task<IActionResult> TestKavenegarSelectOutbox()
        {
            await _smsClientKavenagar.SelectOutboxKaveTest();
            return Ok("done");
        }



        [HttpGet]
        [Route("Test/KavenegarSelect")]
        public async Task<IActionResult> TestKavenegarSelect()
        {
            await _smsClientKavenagar.SelectKaveTest();
            return Ok("done");
        }


        [HttpPost]
        [Route("Test/KavenegarSendArray")]
        public async Task<IActionResult> TestKavenegarSendArray()
        {
            await _smsClientKavenagar.SendArrayKeveTest();
            return Ok("done");
        }


        [HttpPost]
        [Route("Test/KavenegarSendSimple")]
        public async Task<IActionResult> TestKavenegarSendSimple()
        {
            await _smsClientKavenagar.SendSimpleKaveTest();
            return Ok("done");
        }


        [HttpGet]
        [Route("Test/KavenegarStatusByMessage")]
        public async Task<IActionResult> TestKavenegarStatusByMessage()
        {
            await _smsClientKavenagar.StatusByMessageKaveTest();
            return Ok("done");
        }


        [HttpGet]
        [Route("Test/KavenegarStatus")]
        public async Task<IActionResult> TestKavenegarStatus()
        {
            await _smsClientKavenagar.StatusKaveTest();
            return Ok("done");
        }

        ///////////////////////////////////////////
        ///Magfa

        [HttpGet]
        [Route("Test/MagfaMessage")]
        public async Task<IActionResult> TestMagfaMessage()
        {
            await _smsClientMagfa.MessageMagfaTest();
            return Ok("done");
        }

        [HttpGet]
        [Route("Test/MagfaBalance")]
        public async Task<IActionResult> TestMagfaBalance()
        {
            await _smsClientMagfa.BalanceMagfaTest();
            return Ok("done");
        }

        [HttpGet]
        [Route("Test/MagfaMid")]
        public async Task<IActionResult> TestMagfaMid()
        {
            await _smsClientMagfa.MidMagfaTest();
            return Ok("done");
        }

        [HttpPost]
        [Route("Test/MagfaSend")]
        public async Task<IActionResult> TestMagfaSend()
        {
            await _smsClientMagfa.SendMagfaTest();
            return Ok("done");
        }

        [HttpGet]
        [Route("Test/MagfaStatus")]
        public async Task<IActionResult> TestMagfaStatus()
        {
            await _smsClientMagfa.StatusesMagfaTest();
            return Ok("done");
        }


        /////// merge witch dictionary
        [HttpGet]
        [Route("Test/MergeDictionary/GetAccount/{lineId}")]
        public async Task<IActionResult> GetAccount(ProviderEnum lineId)
        {
            await _switchingFactory.GetAccount_Balance(lineId);
            return Ok("done");
        }
        
        
        [HttpGet]
        [Route("Test/MergeDictionary/GetStatusByMessageId/{lineId}/{messageId}")]
        public async Task<IActionResult> GetStatus(ProviderEnum lineId,int messageId)
        {
            await _switchingFactory.GetStatusByMessageId(lineId, messageId);
            return Ok("done");
        }
        
        
        [HttpGet]
        [Route("Test/MergeDictionary/GetReceiveMessage/{lineId}/{count}/{lineNumber}")]
        public async Task<IActionResult> GetReceiveMessage(ProviderEnum lineId,int count,string lineNumber)
        {
            await _switchingFactory.GetReceiveMessages(lineId, count,lineNumber);
            return Ok("done");
        }
        
        
        [HttpPost]
        [Route("Test/MergeDictionary/SendMessage/{lineId}")]
        public async Task<IActionResult> SendMessage(ProviderEnum lineId,[FromBody]List<SendMessageDto> message)
        {
            await _switchingFactory.SendMessages(lineId,message);
            return Ok("done");
        }
        
        
        
        [HttpGet]
        [Route("Test/MergeDictionary/GetStatusByLocalMessageId/{lineId}/{localMessageId}")]
        public async Task<IActionResult> GetStatusByLocalMessageId(ProviderEnum lineId,long localMessageId)
        {
            await _switchingFactory.GetStatusByLocalMessageId(lineId, localMessageId);
            return Ok("done");
        }
        
        
        [HttpGet]
        [Route("Test/MergeDictionary/GetMessageIdByUserId/{lineId}/{userId}")]
        public async Task<IActionResult> GetMessageIdByUserId(ProviderEnum lineId,long userId)
        {
            await _switchingFactory.GetMessageIdByUserId(lineId, userId);
            return Ok("done");
        }
        
        
        [HttpGet]
        [Route("Test/MergeDictionary/GetMessageInfoByMessageId/{lineId}/{messageId}")]
        public async Task<IActionResult> GetMessageInfoByMessageId(ProviderEnum lineId,long messageId)
        {
            await _switchingFactory.GetMessageInfoByMessageId(lineId, messageId);
            return Ok("done");
        }
        
        
        [HttpGet]
        [Route("Test/MergeDictionary/GetMessageList/{lineId}/{startDate}/{endDate}/{lineNumber}")]
        public async Task<IActionResult> GetMessageList(ProviderEnum lineId,long startDate,long endDate, string lineNumber)
        {
            await _switchingFactory.GetMessageListSent(lineId, startDate,endDate,lineNumber);
            return Ok("done");
        }
        
        
        
        [HttpGet]
        [Route("Test/MergeDictionary/GetMessageLatest/{lineId}/{count}/{lineNumber}")]
        public async Task<IActionResult> GetMessageLatest(ProviderEnum lineId,long count, string lineNumber)
        {
            await _switchingFactory.GetLatestMessageByMessageCount(lineId, count,lineNumber);
            return Ok("done");
        }
        
        
        
        [HttpGet]
        [Route("Test/MergeDictionary/GetMessageCountInbox/{lineId}/{startDate}/{endDate}/{lineNumber}/{isRead}")]
        public async Task<IActionResult> GetMessageCountInbox(ProviderEnum lineId, long startDate, long endDate, string lineNumber,bool isRead)
        {
            await _switchingFactory.GetMessageCountInbox(lineId,startDate,endDate,lineNumber,isRead);
            return Ok("done");
        }
    }
}
