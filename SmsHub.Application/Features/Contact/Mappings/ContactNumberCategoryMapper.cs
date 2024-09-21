using AutoMapper;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Contact.Mappings
{
    public class ContactNumberCategoryMapper:Profile
    {
        public ContactNumberCategoryMapper()
        {
            CreateMap<Entities.ContactNumberCategory, CreateContactNumberCategoryDto>().ReverseMap();
        }
    }
}
