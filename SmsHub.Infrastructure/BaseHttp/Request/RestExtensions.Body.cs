using Newtonsoft.Json;
using SmsHub.Common.Extensions;
using SmsHub.Infrastructure.BaseHttp.Enums;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;

namespace SmsHub.Infrastructure.BaseHttp.Request
{
    public static partial class RestExtensions
    {
        public static HttpRequestMessage AddStringBody(this HttpRequestMessage request, string body, DataFormat dataFormat)
        {
            var content = new StringContent(body, Encoding.UTF8, "text/xml");
            request.Content = content;
            return request;

            //var contentType = ContentType.FromDataFormat(dataFormat);
            //request.RequestFormat = dataFormat;
            //return request.AddParameter(new BodyParameter("", body, contentType));
        }       
        public static HttpRequestMessage AddBody(this HttpRequestMessage request, string jsonString, [Optional] Encoding encoding, [Optional] ContentType contentType)
        {
            encoding = encoding ?? Encoding.UTF8;
            contentType = contentType ?? ContentType.Json;
            var content = new StringContent(jsonString, encoding, contentType);
            request.Content = content;
            return request;
        }
        public static HttpRequestMessage AddBody<T>(this HttpRequestMessage request, T obj, [Optional] Func<T , string > Serialize, [Optional] Encoding encoding, [Optional] ContentType contentType) where T : class
        {
            if(obj is string str)
            {
                return request.AddStringBody(str, DataFormat.Json);
            }
            encoding = encoding ?? Encoding.UTF8;
            contentType = contentType ?? ContentType.Json;
            var serializer = Serialize ?? JsonConvert.SerializeObject;
            var bodyJson = serializer(obj);
            var content = new StringContent(bodyJson, encoding, contentType);
            request.Content = content;
            return request;
        }

        public static HttpRequestMessage AddFormBody<T>(this HttpRequestMessage request, Dictionary<string,T> formDictionary, [Optional] Encoding encoding, string? mediaType=null)
        {
            request.NotNull();
            formDictionary.NotNull();
            encoding = encoding ?? Encoding.UTF8;
            mediaType= string.IsNullOrWhiteSpace(mediaType) ? MediaTypeNames.Text.Plain : mediaType;
            MultipartFormDataContent formContent = new MultipartFormDataContent();
            foreach (var item in formDictionary)
            {
                if(item.Value is null || item.Key is null)
                {
                    continue;
                }
                if(item.Value is IEnumerable<T>)
                {
                    var values = item.Value as IEnumerable<T>;
                    var sb = new StringBuilder();
                    sb.Append("[").AppendJoin(',', values).Append("]");
                    var content = new StringContent(item.Key, encoding, mediaType);
                    formContent.Add(content, item.Key);
                }
                else
                {
                    var content = new StringContent(item.Key, encoding, mediaType);
                    formContent.Add(content, item.Key);
                }              
            }
            request.Content = formContent;
            return request;

            /*var client = new HttpClient();
var request = new HttpRequestMessage(HttpMethod.Post, "https://api.kavenegar.com/v1/5575426A68495063786333776662677171397533775377746A5A696475386159574332463078442F7750553D/sms/sendarray.json");
request.Headers.Add("Cookie", "cookiesession1=678A8C4023F49FF44F4B75F55D3B7902");
var content = new MultipartFormDataContent();
content.Add(new StringContent("[\"09134588220\",\"09135742556\"]"), "receptor");
content.Add(new StringContent("[\"2000550055505\",\"2000550055505\"]"), "sender");
content.Add(new StringContent("[\"سلام این پیام جهت تست است\",\"سلام این پیام جهت تست است\"]"), "message");
content.Add(new StringContent("[\"4563324XX\",\"123644YY\"]"), "localmessageids");
request.Content = content;
var response = await client.SendAsync(request);
response.EnsureSuccessStatusCode();
Console.WriteLine(await response.Content.ReadAsStringAsync());
*/
        }

        //TODO: ADD Xml body
    }
}
