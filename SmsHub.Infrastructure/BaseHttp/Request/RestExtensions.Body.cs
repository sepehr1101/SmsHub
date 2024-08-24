using SmsHub.Infrastructure.BaseHttp.Enums;
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
        public static HttpRequestMessage AddJsonBody(this HttpRequestMessage request, string jsonString, bool forceSerialize, ContentType? contentType = null)
        {

            var content = new StringContent(jsonString, Encoding.UTF8, ContentType.Json);
            request.Content = content;
            return request;
        }
        public static HttpRequestMessage AddJsonBody<T>(this HttpRequestMessage request, T obj, Func<T , string > Func, ContentType? contentType = null) where T : class
        {
            if(obj is string str)
            {
                return request.AddStringBody(str, DataFormat.Json);
            }
            var bodyJson = Func(obj);
            var content = new StringContent(bodyJson, Encoding.UTF8, ContentType.Json);
            request.Content = content;
            return request;
        }

        //TODO: ADD Xml body
    }
}
