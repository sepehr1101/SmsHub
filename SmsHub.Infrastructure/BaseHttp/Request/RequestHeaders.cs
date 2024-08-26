using SmsHub.Infrastructure.BaseHttp.Parameters;
using SmsHub.Common.Extensions;
using System.Net;

namespace SmsHub.Infrastructure.BaseHttp.Request
{
    class RequestHeaders : ParametersCollection<HeaderParameter>
    {
        public RequestHeaders AddHeaders(ParametersCollection parameters)
        {
            Parameters.AddRange(parameters.GetParameters<HeaderParameter>());
            return this;
        }

        public RequestHeaders AddAcceptHeader(string[] acceptedContentTypes)
        {
            if (TryFind(KnownHeaders.Accept) == null)
            {
                var accepts = acceptedContentTypes.JoinToString(", ");
                Parameters.Add(new(KnownHeaders.Accept, accepts));
            }

            return this;
        }
               
        public RequestHeaders AddCookieHeaders(Uri uri, CookieContainer? cookieContainer)
        {
            if (cookieContainer == null) return this;

            var cookies = cookieContainer.GetCookieHeader(uri);

            if (string.IsNullOrWhiteSpace(cookies)) return this;

            var newCookies = SplitHeader(cookies);
            var existing = GetParameters<HeaderParameter>().FirstOrDefault(x => x.Name == KnownHeaders.Cookie);

            if (existing?.Value != null)
            {
                newCookies = newCookies.Union(SplitHeader(existing.Value!));
            }

            Parameters.Add(new(KnownHeaders.Cookie, string.Join("; ", newCookies)));

            return this;

            IEnumerable<string> SplitHeader(string header) => header.Split(';').Select(x => x.Trim());
        }
    }
}
