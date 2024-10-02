using AutoMapper;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Logging.Mapping
{
    public   class InformativeLogMapper:Profile
    {
        public InformativeLogMapper()
        {
            CreateMap<InformativeLog, CreateInformativeLogDto>().ReverseMap();
            CreateMap<UpdateInformativeLogDto, InformativeLog > ().ReverseMap();
        }
    }
}
