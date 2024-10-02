using AutoMapper;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Config.Mappings
{
    public class ConfigTypeMapper :Profile
    {
        public ConfigTypeMapper()
        {
            CreateMap<ConfigType, CreateConfigTypeDto>().ReverseMap();
            CreateMap<UpdateConfigTypeDto, ConfigType>().ReverseMap();
        }
    }
}
