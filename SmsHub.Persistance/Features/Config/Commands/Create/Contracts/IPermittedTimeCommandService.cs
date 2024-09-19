namespace SmsHub.Persistence.Features.Config.Commands.Create.Contracts
{
    public interface IPermittedTimeCommandService
    {
        Task Add(Domain.Features.Entities.PermittedTime permittedTime);
        Task Add(ICollection<Domain.Features.Entities.PermittedTime> permittedTimes);
    }
}
