using Newtonsoft.Json;
using SmsHub.Infrastructure.BaseHttp.Enums;
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
            Serialize = JsonConvert.SerializeObject;
            var bodyJson = Serialize(obj);
            var content = new StringContent(bodyJson, encoding, contentType);
            request.Content = content;
            return request;
        }

        //TODO: ADD Xml body
    }
}
