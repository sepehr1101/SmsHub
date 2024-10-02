using AutoMapper;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Config.Mappings
{
    public class ConfigMapper:Profile
    {
        public ConfigMapper()
        {
            CreateMap< CreateConfigDto,Entities.Config > ().ReverseMap();
            CreateMap<UpdateConfigDto, Entities.Config>().ReverseMap();
            CreateMap<GetConfigDto, Entities.Config>().ReverseMap();
        }
    }
}
