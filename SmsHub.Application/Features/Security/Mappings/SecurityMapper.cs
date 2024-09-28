using AutoMapper;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Security.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Security.Mappings
{
    public class SecurityMapper: Profile
    {
        public SecurityMapper()
        {
            CreateMap<ServerUser, CreateServerUserDto>()
                .ReverseMap()
                .ForMember(x=> x.CreateDateTime, opt=> opt.MapFrom(s=> DateTime.Now));
        }
    }
}
