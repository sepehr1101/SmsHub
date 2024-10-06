using AutoMapper;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Update;

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
