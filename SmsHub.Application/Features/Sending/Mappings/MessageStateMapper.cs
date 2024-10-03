using AutoMapper;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Sending.Mappings
{
    public class MessageStateMapper:Profile
    {
        public MessageStateMapper()
        {
            CreateMap<CreateMessageStateDto, MessageState>().ReverseMap();
            CreateMap<UpdateMessageStateDto, MessageState > ().ReverseMap();
            CreateMap<GetMessageStateDto, MessageState > ().ReverseMap();
        }
    }
}
