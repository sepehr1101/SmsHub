using AutoMapper;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Config.Mappings
{
    public class ConfigTypeGroupMapper:Profile
    {
        public ConfigTypeGroupMapper()
        {
            CreateMap< CreateConfigTypeGroupDto, ConfigTypeGroup>().ReverseMap();
            CreateMap<UpdateConfigTypeGroupDto, ConfigTypeGroup>().ReverseMap();
            CreateMap<GetConfigTypeGroupDto, ConfigTypeGroup>().ReverseMap();
        }
    }
}
