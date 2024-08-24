using SmsHub.Infrastructure.BaseHttp.Parameters;
using System.Net.Http.Headers;
using SmsHub.Common.Extensions;

namespace SmsHub.Infrastructure.BaseHttp.Request
{
    public static partial class RestExtensions
    {
        //public static void AddHeaders(this HttpRequestMessage message, RequestHeaders headers)
        //{
        //    var headerParameters = headers.Where(x => !KnownHeaders.IsContentHeader(x.Name));

        //    headerParameters.GroupBy(x => x.Name).ForEach(x => AddHeader(x, message.Headers));
        //    return;

        //    void AddHeader(IGrouping<string, HeaderParameter> group, HttpHeaders httpHeaders)
        //    {
        //        var parameterStringValues = group.Select(x => x.Value);

        //        httpHeaders.Remove(group.Key);
        //        httpHeaders.TryAddWithoutValidation(group.Key, parameterStringValues);
        //    }
        //}
    }
}
