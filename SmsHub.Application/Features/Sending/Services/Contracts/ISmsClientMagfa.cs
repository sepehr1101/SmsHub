namespace SmsHub.Application.Features.Sending.Services.Contracts
{
    public interface ISmsClientMagfa
    {
        Task BalanceMagfaTest();
        Task MessageMagfaTest();
        Task MidMagfaTest();
        Task SendMagfaTest();
        Task StatusesMagfaTest();

    }
}