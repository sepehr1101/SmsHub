using AutoMapper;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Contact.Mappings
{
    public class ContactMapper : Profile
    {
        public ContactMapper()
        {
            CreateMap< CreateContactDto, Entities.Contact>().ReverseMap();
            CreateMap<UpdateContactDto, Entities.Contact>().ReverseMap();
            CreateMap<GetContactDto, Entities.Contact>().ReverseMap();
        }
    }
}
