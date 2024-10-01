using AutoMapper;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Logging.Mapping
{
    public class DeepLogMapper:Profile
    {
        public DeepLogMapper()
        {
            CreateMap<DeepLog, CreateDeepLogDto>().ReverseMap();
            CreateMap<UpdateDeepLogDto, DeepLog>().ReverseMap();
        }
    }
}
