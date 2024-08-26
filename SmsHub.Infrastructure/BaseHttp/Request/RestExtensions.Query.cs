using SmsHub.Common;
using System.Collections;

namespace SmsHub.Infrastructure.BaseHttp.Request
{
    public static partial class RestExtensions
    {
        public static Uri AddQueryToUri(this Uri uri, string? query)
        {
            if (query == null)
            {
                return uri;
            }

            var absoluteUri = uri.AbsoluteUri;
            var separator = absoluteUri.Contains('?') ? "&" : "?";

            return new($"{absoluteUri}{separator}{query}");
        }
        public static HttpRequestMessage AddQuery(this HttpRequestMessage request, string key, string value)
        {
            if (key is null || value is null || request.RequestUri is null)
            {
                return request;
            }
            string query = $"{value}={key}";
            request.RequestUri = request.RequestUri.AddQueryToUri(query);
            return request;
        }
        public static HttpRequestMessage AddQuery(this HttpRequestMessage request ,object obj, string separator = ",")
        {
            obj.NotNull(nameof(obj));
            request.NotNull(nameof(request));
           
            var properties = obj.GetType().GetProperties()
                .Where(x => x.CanRead)
                .Where(x => x.GetValue(obj, null) != null)
                .ToDictionary(x => x.Name, x => x.GetValue(obj, null));

            var propertyNames = properties
                .Where(x => !(x.Value is string) && x.Value is IEnumerable)
                .Select(x => x.Key)
                .ToList();

            foreach (var key in propertyNames)
            {
                var valueType = properties[key].GetType();
                var valueElemType = valueType.IsGenericType
                                        ? valueType.GetGenericArguments()[0]
                                        : valueType.GetElementType();
                if (valueElemType.IsPrimitive || valueElemType == typeof(string))
                {
                    var enumerable = properties[key] as IEnumerable;
                    properties[key] = string.Join(separator, enumerable.Cast<object>());
                }
            }

            var query= string.Join("&", properties
                .Select(x => string.Concat(
                    Uri.EscapeDataString(x.Key), "=",
                    Uri.EscapeDataString(x.Value.ToString()))));
            request.RequestUri = request?.RequestUri.AddQueryToUri(query);
            return request;
        }
    }
}
