namespace SmsHub.Persistence.Features.Config.Commands.Create.Contracts
{
    public interface IConfigCommandService
    {
        Task Add(Domain.Features.Entities.Config config);
        Task Add(ICollection<Domain.Features.Entities.Config> configs);
    }
}
