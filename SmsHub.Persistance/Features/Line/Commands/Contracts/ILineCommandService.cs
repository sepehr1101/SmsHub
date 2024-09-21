namespace SmsHub.Persistence.Features.Line.Commands.Contracts
{
    public interface ILineCommandService
    {
        Task Add(Domain.Features.Entities.Line line);
        Task Add(ICollection<Domain.Features.Entities.Line> lines); 
    }
}
