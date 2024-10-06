using AutoMapper;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Sending.Mappings
{
    public class MessageStateCategoryMapper:Profile
    {
        public MessageStateCategoryMapper()
        {
            CreateMap<CreateMessageStateCategoryDto, MessageStateCategory>().ReverseMap();
            CreateMap<UpdateMessageStateCategoryDto, MessageStateCategory > ().ReverseMap();
            CreateMap<GetMessageStateCategoryDto, MessageStateCategory > ().ReverseMap();
        }
    }
}
