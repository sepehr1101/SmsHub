using AutoMapper;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Contact.Mappings
{
    public class ContactNumberMapper:Profile
    {
        public ContactNumberMapper()
        {
            CreateMap<ContactNumber, CreateContactNumberDto>().ReverseMap();
            CreateMap<UpdateContactNumberDto,ContactNumber>().ReverseMap();
        }
    }
}
