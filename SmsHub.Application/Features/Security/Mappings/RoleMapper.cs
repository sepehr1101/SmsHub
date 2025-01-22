using AutoMapper;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Domain.Features.Security.Entities;

namespace SmsHub.Application.Features.Security.Mappings
{
    public class RoleMapper : Profile
    {
        public RoleMapper()
        {
            CreateMap<GetRoleDto, Role>().ReverseMap();
        }
    }
}
