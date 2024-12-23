namespace SmsHub.Application.Features.Sending.Services.Contracts
{
    public interface ISwitchBetweenProvider
    {
        Task SwitchAcountBalance(int lineId);
    }
}
