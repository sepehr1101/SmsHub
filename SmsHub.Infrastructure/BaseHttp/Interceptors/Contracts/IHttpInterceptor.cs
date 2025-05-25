namespace SmsHub.Infrastructure.BaseHttp.Interceptors.Contracts
{
    public interface IHttpInterceptor
    {
        Task OnRequestAsync(HttpRequestMessage request);
        Task OnResponseAsync(HttpResponseMessage response);
    }
}