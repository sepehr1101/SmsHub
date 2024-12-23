namespace SmsHub.Application.Features.Sending.Services.Contracts
{
    public interface ISwitchKavenagarMagfa
    {
        Task SwitchAcountBalance(int lineId);
    }
}
