using AutoMapper;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Sending.Mappings
{
    public class MessageHolderMapper:Profile
    {
        public MessageHolderMapper()
        {
            CreateMap<Entities.MessagesHolder, CreateMessagesHolderDto>().ReverseMap();
        }
    }
}
