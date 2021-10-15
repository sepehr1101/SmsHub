using SmsHub.Core.Constants;
using SmsHub.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace SmsHub.Core.Http
{
    public static class Client
    {
        private static string _soapAction { get { return "SOAPAction"; } }
        private static string _invalidJson { get { return "Invalid JSON or generic type not match with the json"; } } 
        private static string _notMatchingType { get { return "HTTP Response was invalid and cannot be deserialised"; } }

        public static async Task<HttpResponseMessage> PostSoap(this HttpClient client, string soapEnvelop, string uri, AuthenticationHeaderValue authHeaderVal, string soapAction = "")
        {
            var httpRequestMessage = CreateRequestMessage(soapEnvelop, uri, authHeaderVal, soapAction);
            var responseMessage = await client.SendAsync(httpRequestMessage).ConfigureAwait(false);
            return responseMessage;
        }
        private static HttpRequestMessage CreateRequestMessage(string soapEnvelop, string uri, AuthenticationHeaderValue authHeaderVal, string soapAction)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);
            var content = new StringContent(soapEnvelop, Encoding.UTF8, MediaTypes.TextXml);
            if (authHeaderVal != null)
            {
                httpRequestMessage.Headers.Authorization = authHeaderVal;
            }
            httpRequestMessage.Headers.Add(_soapAction, soapAction);
            httpRequestMessage.Content = content;
            return httpRequestMessage;
        }
        
        public static async Task<HttpResponseWrapper<T>> Post<T>(this HttpClient client, object body, string uri, AuthenticationHeaderValue authHeaderVal=null, Dictionary<string, string> headers=null)
        {
            var httpRequestMessage = CreateRequestMessage(body, uri, authHeaderVal, headers);
            var responseMessage = await client.SendAsync(httpRequestMessage).ConfigureAwait(false);
            var httpResponseWrappar = new HttpResponseWrapper<T>() { HttpResponseMessage = responseMessage };
            if(responseMessage.Content is object && responseMessage.Content.Headers?.ContentType?.MediaType == MediaTypes.ApplicationJson)
            {
                var jsonOption = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                try
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        httpResponseWrappar.ResponseBody = JsonSerializer.Deserialize<T>(jsonString, jsonOption);
                    }
                }
                catch (JsonException)
                {
                    httpResponseWrappar.Error = _invalidJson;
                }
            }
            else
            {
                var textReponse= await responseMessage.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(textReponse) && typeof(T)==typeof(string))
                {
                    httpResponseWrappar.ResponseBody = (T)Convert.ChangeType(textReponse, typeof(T));
                }
                else
                {
                    httpResponseWrappar.Error = _notMatchingType;
                }
            }
            return httpResponseWrappar;
        }
        private static HttpRequestMessage CreateRequestMessage(object body, string uri, AuthenticationHeaderValue authHeaderVal, Dictionary<string, string> headers)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);
            var bodyJson = JsonSerializer.Serialize(body);
            var content = new StringContent(bodyJson, Encoding.UTF8, MediaTypes.ApplicationJson);
            if (authHeaderVal != null)
            {
                httpRequestMessage.Headers.Authorization = authHeaderVal;
            }
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    httpRequestMessage.Headers.Add(header.Key, header.Value);
                }
            }
            httpRequestMessage.Content = content;
            return httpRequestMessage;
        }
    }
}
