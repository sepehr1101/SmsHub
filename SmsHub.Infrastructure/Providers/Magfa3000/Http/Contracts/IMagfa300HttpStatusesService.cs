using MagfaRequest=SmsHub.Domain.Providers.Magfa3000.Entities.Requests;
using SmsHub.Domain.Providers.Kavenegar.Entities.Responses;

namespace SmsHub.Infrastructure.Providers.Magfa3000.Http.Contracts
{
    public interface IMagfa300HttpStatusesService
    {
        Task<MagfaRequest.Statuses> GetStatuses(StatusDto statusDto);
    }
}
