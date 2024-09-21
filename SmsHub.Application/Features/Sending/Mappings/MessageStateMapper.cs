using AutoMapper;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Sending.Mappings
{
    public class MessageStateMapper:Profile
    {
        public MessageStateMapper()
        {
            CreateMap<Entities.MessageState, CreateMessageStateDto>().ReverseMap();
        }
    }
}
