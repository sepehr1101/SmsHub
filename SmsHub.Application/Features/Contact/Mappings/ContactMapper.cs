using AutoMapper;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Contact.Mappings
{
    public class ContactMapper : Profile
    {
        public ContactMapper()
        {
            CreateMap<Entities.Contact, CreateContactDto>().ReverseMap();
        }
    }
}
