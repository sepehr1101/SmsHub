using AutoMapper;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Sending.Mappings
{
    public class MessageStateCategoryMapper:Profile
    {
        public MessageStateCategoryMapper()
        {
            CreateMap<MessageStateCategory, CreateMessageStateCategoryDto>().ReverseMap();
            CreateMap<UpdateMessageStateCategoryDto, MessageStateCategory > ().ReverseMap();
        }
    }
}
