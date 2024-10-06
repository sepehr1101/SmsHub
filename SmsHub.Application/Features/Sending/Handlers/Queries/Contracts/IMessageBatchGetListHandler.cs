using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Sending.Handlers.Queries.Contracts
{
    public interface IMessageBatchGetListHandler
    {
        Task<ICollection<GetMessageBatchDto>> Handle();
    }
}
