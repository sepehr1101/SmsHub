using AutoMapper;
using SmsHub.Domain.Features.Config.PersistenceDto.Commands;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Config.Mappings
{
    public class ConfigTypeMapper :Profile
    {
        public ConfigTypeMapper()
        {
            CreateMap<Entities.ConfigType, CreateConfigTypeDto>().ReverseMap();
        }
    }
}
