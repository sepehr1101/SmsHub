using AutoMapper;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Update;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Config.Mappings
{
    public class PermittedTimeMapper:Profile
    {
        public PermittedTimeMapper()
        {
            CreateMap<PermittedTime, CreatePermittedTimeDto>().ReverseMap();
            CreateMap<UpdatePermittedTimeDto, PermittedTime>().ReverseMap();
        }
    }
}
