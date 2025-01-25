using SmsHub.Domain.Features.Line.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Line.Handlers.Queries.Contracts
{
    public interface ILineGetAllDictionaryHandler
    {
        Task<ICollection<LineDictionary>> Handle();
    }
}
