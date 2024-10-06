using AutoMapper;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Update;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Contact.Mappings
{
    public class ContactCategoryMapper:Profile
    {
        public ContactCategoryMapper()
        {
            CreateMap<ContactCategory, CreateContactCategoryDto>().ReverseMap();
            CreateMap<UpdateContactCategoryDto, ContactCategory>().ReverseMap();
        }
    }
}
