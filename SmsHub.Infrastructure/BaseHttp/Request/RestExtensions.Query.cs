using SmsHub.Common;
using SmsHub.Common.Extensions;
using SmsHub.Infrastructure.BaseHttp.Parameters;

namespace SmsHub.Infrastructure.BaseHttp.Request
{
    public static partial class RestExtensions
    {
        public static Uri AddQueryString(this Uri uri, string? query)
        {
            if (query == null)
            {
                return uri;
            }

            var absoluteUri = uri.AbsoluteUri;
            var separator = absoluteUri.Contains('?') ? "&" : "?";

            return new($"{absoluteUri}{separator}{query}");
        }
        public static UrlSegmentParamsValues GetUrlSegmentParamsValues(
       this Uri? baseUri,
       string resource,
       Func<string, string> encode,
       params ParametersCollection[] parametersCollections
   )
        {
            var assembled = baseUri == null ? "" : resource;
            var baseUrl = baseUri ?? new Uri(resource);

            var hasResource = !assembled.IsEmpty();

            var parameters = parametersCollections.SelectMany(x => x.GetParameters<UrlSegmentParameter>());

            var builder = new UriBuilder(baseUrl);

            foreach (var parameter in parameters)
            {
                var paramPlaceHolder = $"{{{parameter.Name}}}";
                var value = Guard.NotNull(parameter.Value!.ToString(), $"URL segment parameter {parameter.Name} value");
                var paramValue = parameter.Encode ? encode(value) : value;

                if (hasResource) assembled = assembled.Replace(paramPlaceHolder, paramValue);

                builder.Path = builder.Path.UrlDecode().Replace(paramPlaceHolder, paramValue);
            }

            return new UrlSegmentParamsValues(builder.Uri, assembled);
        }
    }
}
