using AutoMapper;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Update;

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
