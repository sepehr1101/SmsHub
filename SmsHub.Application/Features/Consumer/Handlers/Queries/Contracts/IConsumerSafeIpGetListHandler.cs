using SmsHub.Domain.Features.Consumer.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Consumer.Handlers.Queries.Contracts
{
    public interface IConsumerSafeIpGetListHandler
    {
        Task<ICollection<GetConsumerSafaIpDto>>  Handle();
    }
}
