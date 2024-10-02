using AutoMapper;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Sending.Mappings
{
    public class MessageStateMapper:Profile
    {
        public MessageStateMapper()
        {
            CreateMap<MessageState, CreateMessageStateDto>().ReverseMap();
            CreateMap<UpdateMessageStateDto, MessageState > ().ReverseMap();
        }
    }
}
