using SmsHub.Infrastructure.BaseHttp.Client.Implementation;

namespace SmsHub.Infrastructure.BaseHttp.Client.Contracts
{
    public interface IRestClient
    {
        RestClient Create(Uri uri);
    }
}