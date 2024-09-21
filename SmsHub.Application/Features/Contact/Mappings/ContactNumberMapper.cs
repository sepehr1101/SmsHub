using AutoMapper;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Contact.Mappings
{
    public class ContactNumberMapper:Profile
    {
        public ContactNumberMapper()
        {
            CreateMap<Entities.ContactNumber, CreateContactNumberDto>().ReverseMap();
        }
    }
}
