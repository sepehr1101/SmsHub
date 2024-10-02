using Entities= SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Line.Commands.Contracts
{
    public interface IProviderCommandService
    {
        Task Add(Entities.Provider provider);
        Task Add(ICollection<Entities.Provider> provider);
        void Delete(Entities.Provider provider);
    }
}
