using AutoMapper;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Update;
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
