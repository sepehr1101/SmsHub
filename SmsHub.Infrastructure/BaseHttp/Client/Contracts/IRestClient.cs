using SmsHub.Infrastructure.BaseHttp.Client.Implementation;

namespace SmsHub.Infrastructure.BaseHttp.Client.Contracts
{
    internal interface IRestClient
    {
        RestClient Create(string url);
    }
}