using AutoMapper;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Config.Mappings
{
    public class ConfigTypeMapper :Profile
    {
        public ConfigTypeMapper()
        {
            CreateMap<CreateConfigTypeDto, ConfigType>().ReverseMap();
            CreateMap<UpdateConfigTypeDto, ConfigType>().ReverseMap();
            CreateMap<GetConfigTypeDto, ConfigType>().ReverseMap();
        }
    }
}
