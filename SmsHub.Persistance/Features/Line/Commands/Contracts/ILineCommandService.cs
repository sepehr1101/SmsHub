using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Line.Commands.Contracts
{
    public interface ILineCommandService
    {
        Task Add(Entities.Line line);
        Task Add(ICollection<Entities.Line> lines); 
        void Delete(Entities.Line line);
    }
}
