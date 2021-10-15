using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Rahyab.HttpService;
using SmsHub.Core.Dtos;
using SmsHub.Rahyab.Dtos.Output;

namespace SmsHub.WebTest.Controllers
{
    [Route("Rahyab")]
    [ApiController]
    public class RahyabController : ControllerBase
    {
        private readonly IHttpService _rayhabClient;
        public RahyabController(IHttpService rahyabService)
        {
            _rayhabClient = rahyabService;
        }
        [HttpGet]
        [Route("SendTest")]
        public async Task<IActionResult> SendTest()
        {
            //var list = new List<MobileText>()
            //{
            //    new MobileText(){Mobile="09135742556",Text="پیامک از SDK 1"},
            //    new MobileText(){Mobile="09135742556",Text="پیامک از SDK 2"}
            //};
            //var sendOutput = await _rayhabClient.Send(list);
            //var result = await _rayhabClient.GetDeliveryStatus(sendOutput.First().Identity);
            var sendSimple = await _rayhabClient.Send(new MobileText() { Mobile = "09135742556", Text = "From SDK Simple" });
            var sendBatch = await _rayhabClient.Send(new[] { "09135742556" }, "From SDK Batch");
            var result = await _rayhabClient.GetDeliveryStatus(sendBatch.First().BatchId);
            var result2 = await _rayhabClient.GetDeliveryStatus(sendSimple.Identity);
            return Ok(new { sendSimple, sendBatch,result,result2 });
        }
    }
}
