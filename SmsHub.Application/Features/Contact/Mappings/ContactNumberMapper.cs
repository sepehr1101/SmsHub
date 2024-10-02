using AutoMapper;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Contact.Mappings
{
    public class ContactNumberMapper:Profile
    {
        public ContactNumberMapper()
        {
            CreateMap< CreateContactNumberDto, ContactNumber>().ReverseMap();
            CreateMap<UpdateContactNumberDto,ContactNumber>().ReverseMap();
            CreateMap<GetContactNumberDto,ContactNumber>().ReverseMap();
        }
    }
}
