namespace SmsHub.Persistence.Features.Template.Services.Contracts
{
    public interface ICheckDisallowedPhraseService
    {
        Task Check(string input);
    }
}
