using AutoMapper;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Config.Mappings
{
    public class PermittedTimeMapper:Profile
    {
        public PermittedTimeMapper()
        {
            CreateMap< CreatePermittedTimeDto, PermittedTime>().ReverseMap();
            CreateMap<UpdatePermittedTimeDto, PermittedTime>().ReverseMap();
            CreateMap<GetPermittedTimeDto, PermittedTime>().ReverseMap();
        }
    }
}
