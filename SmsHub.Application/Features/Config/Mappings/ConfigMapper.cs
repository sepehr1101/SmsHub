using AutoMapper;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Config.Mappings
{
    public class ConfigMapper:Profile
    {
        public ConfigMapper()
        {
            CreateMap<Entities.Config, CreateConfigDto>().ReverseMap();
            CreateMap<UpdateConfigDto, Entities.Config>().ReverseMap();
        }
    }
}
