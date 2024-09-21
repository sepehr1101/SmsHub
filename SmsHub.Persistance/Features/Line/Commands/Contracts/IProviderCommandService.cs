namespace SmsHub.Persistence.Features.Line.Commands.Contracts
{
    public interface IProviderCommandService
    {
        Task Add(Domain.Features.Entities.Provider provider);
        Task Add(ICollection<Domain.Features.Entities.Provider> provider);
    }
}
