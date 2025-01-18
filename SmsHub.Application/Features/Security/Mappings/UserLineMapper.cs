using AutoMapper;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Domain.Features.Security.Entities;

namespace SmsHub.Application.Features.Security.Mappings
{
    public class UserLineMapper : Profile
    {
        public UserLineMapper()
        {
            CreateMap<CreateUserLineDto, UserLine>().ReverseMap();
            CreateMap<UpdateUserLineDto, UserLine>().ReverseMap();
        }
    }
}
