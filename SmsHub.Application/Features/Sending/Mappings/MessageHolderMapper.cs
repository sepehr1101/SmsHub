using AutoMapper;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Sending.Mappings
{
    public class MessageHolderMapper:Profile
    {
        public MessageHolderMapper()
        {
            CreateMap<MessagesHolder, CreateMessagesHolderDto>().ReverseMap();
            CreateMap<UpdateMessageHolderDto, MessagesHolder > ().ReverseMap();
        }
    }
}
