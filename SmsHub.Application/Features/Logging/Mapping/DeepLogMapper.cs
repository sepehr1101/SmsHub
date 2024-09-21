using AutoMapper;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Logging.Mapping
{
    public class DeepLogMapper:Profile
    {
        public DeepLogMapper()
        {
            CreateMap<Entities.DeepLog, CreateDeepLogDto>().ReverseMap();
        }
    }
}
