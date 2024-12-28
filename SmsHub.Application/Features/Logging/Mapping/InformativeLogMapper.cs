using AutoMapper;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Logging.Mapping
{
    public   class InformativeLogMapper:Profile
    {
        public InformativeLogMapper()
        {
            CreateMap< CreateInformativeLogDto, InformativeLog>().ReverseMap();
            CreateMap<UpdateInformativeLogDto, InformativeLog > ().ReverseMap();
            CreateMap<GetInforamtaiveLogDto, InformativeLog>().ReverseMap();
        }
    }
}
