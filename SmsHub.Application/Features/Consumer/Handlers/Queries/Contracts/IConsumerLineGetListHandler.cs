using SmsHub.Domain.Features.Consumer.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Consumer.Handlers.Queries.Contracts
{
    public interface IConsumerLineGetListHandler
    {
        Task<ICollection<GetConsumerLineDto>> Handle();
    }
}
