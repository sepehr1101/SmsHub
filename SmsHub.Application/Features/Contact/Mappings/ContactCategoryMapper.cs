using AutoMapper;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Update;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Contact.Mappings
{
    public class ContactCategoryMapper:Profile
    {
        public ContactCategoryMapper()
        {
            CreateMap< CreateContactCategoryDto, ContactCategory>().ReverseMap();
            CreateMap<UpdateContactCategoryDto, ContactCategory>().ReverseMap();
            CreateMap<GetContactCategoryDto, ContactCategory>().ReverseMap();
        }
    }
}
