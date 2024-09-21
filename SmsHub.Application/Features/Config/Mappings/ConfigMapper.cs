using AutoMapper;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Config.PersistenceDto.Commands;

namespace SmsHub.Application.Features.Config.Mappings
{
    public class ConfigMapper:Profile
    {
        public ConfigMapper()
        {
            CreateMap<Entities.Config, CreateConfigDto>().ReverseMap();
        }
    }
}
