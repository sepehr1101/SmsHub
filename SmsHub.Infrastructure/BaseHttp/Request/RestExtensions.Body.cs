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
        public static HttpRequestMessage AddBody<T>(this HttpRequestMessage request, T obj, [Optional] Func<T, string> Serialize, [Optional] Encoding encoding, [Optional] ContentType contentType) where T : class
        {
            if (obj is string str)
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

        public static HttpRequestMessage AddFormBodyMultipart<T>(this HttpRequestMessage request, Dictionary<string, T> formDictionary, [Optional] Encoding encoding, string? mediaType = null)
        {
            request.NotNull();
            formDictionary.NotNull();
            encoding = encoding ?? Encoding.UTF8;
            mediaType = string.IsNullOrWhiteSpace(mediaType) ? MediaTypeNames.Text.Plain : mediaType;
            MultipartFormDataContent formContent = new MultipartFormDataContent();
            foreach (var item in formDictionary)
            {
                if (item.Value is null || item.Key is null)
                {
                    continue;
                }
                if (item.Value is IEnumerable<T>)
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
        }
        public static async Task<HttpRequestMessage> AddFormBodyUrlEncoded(this HttpRequestMessage request, Dictionary<string, object> formDictionary, [Optional] Encoding encoding, string? mediaType = null)
        {
            request.NotNull();
            formDictionary.NotNull();
            encoding = encoding ?? Encoding.UTF8;
            mediaType = string.IsNullOrWhiteSpace(mediaType) ? MediaTypeNames.Text.Plain : mediaType;
            var keyValues = new List<KeyValuePair<string, string>>();
            foreach (var item in formDictionary)
            {
                if (item.Value is null || item.Key is null)
                {
                    continue;
                }
                string value = string.Empty;                
                {
                    
                }
                if(IsEnumerable(item.Value))
                {
                    value = JsonConvert.SerializeObject(item.Value);
                }
                else
                {
                    var stringContent = new StringContent(item.Value.ToString(), encoding, mediaType);
                    value = await stringContent.ReadAsStringAsync();
                }
                var keyValue = new KeyValuePair<string, string>(item.Key, value);
                keyValues.Add(keyValue);
            }
            FormUrlEncodedContent formUrlEncodedContent = new FormUrlEncodedContent(keyValues);
            request.Content = formUrlEncodedContent;
            return request;
        }
        private static bool IsEnumerable(object obj)
        {
            if (obj is IEnumerable<object> ||
                obj is IEnumerable<long> ||
                obj is IEnumerable<int> || 
                obj is IEnumerable<short> )
            {
                return true;
            }
            return false;
        }
      
        //TODO: ADD Xml body
    }
}
