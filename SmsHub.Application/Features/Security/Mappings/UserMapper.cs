using AutoMapper;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Domain.Features.Security.Entities;

namespace SmsHub.Application.Features.Auth.Mappings
{
    public class UserMapper:Profile
    {
        public UserMapper()
        {
            CreateMap<UserCreateDto, User>();
        }
    }
}
