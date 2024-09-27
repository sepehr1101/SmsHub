namespace SmsHub.Persistence.Features.Config.Queries.Contracts
{
    public interface ICcSendQueryService
    {
        Task<ICollection<Domain.Features.Entities.CcSend>> Get();
        Task<Domain.Features.Entities.CcSend> Get(int id);
    }
}
