using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SmsHub.Core.Common;
using SmsHub.Rahyab.Dtos;
using SmsHub.Core.Dtos;
using SmsHub.Core.Http;
using SmsHub.Rahyab.Dtos.Output;
using SmsHub.Rahyab.Dtos.Input;
using SmsHub.Core;
using System.Net.Http.Headers;
using SmsHub.Core.Constants;
using System.Linq;
using SmsHub.Rahyab.Dtos.Base;

namespace SmsHub.Rahyab.HttpService
{
    public interface IHttpService
    {
        Task<string> GetToken(UsernamePassword usernamePassword);
        Task<ICollection<SendOutput>> Send(SendInput input, string token);
        Task<SendOutput> Send(SendInputSingle input, string token);
        Task<ICollection<SendOutputBatch>> Send(SendInputBatch input, string token);
        Task<ICollection<DeliveryOutput>> GetDeliveryStatus(DeliveryInput input, string token);

        Task<string> GetToken();
        Task<ICollection<SendOutput>> Send(ICollection<MobileText> mobileTexts);
        Task<SendOutput> Send(MobileText mobileText);
        Task<ICollection<SendOutputBatch>> Send(ICollection<string> mobiles, string message);
        Task<ICollection<DeliveryOutput>> GetDeliveryStatus(Guid batchId);
    }
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly RahyabSetting _rahyabSetting;
        public HttpService(HttpClient httpClient, RahyabSetting rahyabSetting=null)
        {
            _httpClient = httpClient;
            GuardExtensions.CheckArgumentIsNull(_httpClient);

            _rahyabSetting = rahyabSetting;
        }

        public async Task<string> GetToken(UsernamePassword usernamePassword)
        {            
            var responseWrapper = await _httpClient.Post<string>(usernamePassword, Literals.Urls.AuthUrl);
            return responseWrapper.ResponseBody;
        }
        public async Task<ICollection<SendOutput>> Send(SendInput input,string token)
        {
            return await Send<SendInput, ICollection<SendOutput>>(input, Literals.Urls.PeerToPeerUrl, token);
        }
        public async Task<SendOutput> Send(SendInputSingle input,string token)
        {
            return await Send<SendInputSingle, SendOutput>(input, Literals.Urls.SingleUrl, token);
        }
        public async Task<ICollection<SendOutputBatch>> Send(SendInputBatch input, string token)
        {
            return await Send<SendInputBatch, ICollection<SendOutputBatch>>(input, Literals.Urls.BatchUrl, token);
        }
        public async Task<ICollection<DeliveryOutput>> GetDeliveryStatus(DeliveryInput input,string token)
        {
           return await Send<DeliveryInput, ICollection<DeliveryOutput>>(input, Literals.Urls.DeliveryUrl, token);           
        }
        private async Task<Output> Send<Input,Output>(Input input,string url,string token)
        {
            var responseWrapper = await _httpClient.Post<Output>(input, url, GetJwtHeader(token));
            return responseWrapper.ResponseBody;
        }
        
        public async Task<string> GetToken()
        {
            GuardExtensions.CheckArgumentIsNull(_rahyabSetting);
            var usernamePassword = new UsernamePassword()
            {
                Username = _rahyabSetting.Username,
                Password = _rahyabSetting.Password
            };
            return await GetToken(usernamePassword);
        }
        public async Task<ICollection<SendOutput>> Send(ICollection<MobileText> mobileTexts)
        {
            GuardExtensions.CheckArgumentIsNull(_rahyabSetting);
            var sendInput = new SendInput()
            {
                Company = _rahyabSetting.Company,
                ListLikeToLikeMessage = mobileTexts.Select(m => new ListLikeToLikeMessage()
                {
                    DestNumber = m.Mobile,
                    Message = m.Text,
                    MessageId = m.MessageId
                }).ToList(),
                Number = _rahyabSetting.Number,
                Password = _rahyabSetting.Password,
                Username = _rahyabSetting.Username
            };
            return await Send(sendInput, _rahyabSetting.Token);
        }
        public async Task<SendOutput> Send(MobileText mobileText)
        {
            GuardExtensions.CheckArgumentIsNull(_rahyabSetting);
            var sendInputSingle = new SendInputSingle()
            {
                Company = _rahyabSetting.Company,
                Number = _rahyabSetting.Number,
                Password = _rahyabSetting.Password,
                Username = _rahyabSetting.Username,
                DestinationAddress = mobileText.Mobile,
                Message = mobileText.Text,
                MessageId = mobileText.MessageId
            };
            return await Send(sendInputSingle, _rahyabSetting.Token);
        }
        public async Task<ICollection<SendOutputBatch>> Send(ICollection<string> mobiles,string message)
        {
            GuardExtensions.CheckArgumentIsNull(_rahyabSetting);
            var sendInput = new SendInputBatch()
            {
                Company = _rahyabSetting.Company,
                Number = _rahyabSetting.Number,
                Password = _rahyabSetting.Password,
                Username = _rahyabSetting.Username,
                DestinationAddress = mobiles,
                Message = message
            };
            return await Send(sendInput, _rahyabSetting.Token);
        }
        public async Task<ICollection<DeliveryOutput>> GetDeliveryStatus(Guid batchId)
        {
            GuardExtensions.CheckArgumentIsNull(_rahyabSetting);
            var deliveryInput = new DeliveryInput()
            {
                BatchId = batchId,
                Company = _rahyabSetting.Company,
                Password = _rahyabSetting.Password,
                Username = _rahyabSetting.Username
            };
            return await GetDeliveryStatus(deliveryInput, _rahyabSetting.Token);
        }

        private AuthenticationHeaderValue GetJwtHeader(string token)
        {
            AuthenticationHeaderValue authHeader = new AuthenticationHeaderValue(HeaderValueOrKey.Bearer, token);
            return authHeader;
        }
    }
}
