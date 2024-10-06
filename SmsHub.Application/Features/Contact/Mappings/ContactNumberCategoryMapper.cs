using AutoMapper;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Contact.Mappings
{
    public class ContactNumberCategoryMapper:Profile
    {
        public ContactNumberCategoryMapper()
        {
            CreateMap< CreateContactNumberCategoryDto, ContactNumberCategory>().ReverseMap();
            CreateMap<UpdateContactNumberCategoryDto,ContactNumberCategory>().ReverseMap();
            CreateMap<GetContactNumberCategoryDto,ContactNumberCategory>().ReverseMap();
        }
    }
}
