using AutoMapper;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Update;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Config.Mappings
{
    public class ConfigTypeGroupMapper:Profile
    {
        public ConfigTypeGroupMapper()
        {
            CreateMap<ConfigTypeGroup, CreateConfigTypeGroupDto>().ReverseMap();
            CreateMap<UpdateConfigTypeGroupDto, ConfigTypeGroup>().ReverseMap();
        }
    }
}
