using AutoMapper;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Update;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Contact.Mappings
{
    public class ContactNumberCategoryMapper:Profile
    {
        public ContactNumberCategoryMapper()
        {
            CreateMap<ContactNumberCategory, CreateContactNumberCategoryDto>().ReverseMap();
            CreateMap<UpdateContactNumberCategoryDto,ContactNumberCategory>().ReverseMap();
        }
    }
}
