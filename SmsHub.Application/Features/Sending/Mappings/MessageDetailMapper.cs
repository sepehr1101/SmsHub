using AutoMapper;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Sending.Mappings
{
    public class MessageDetailMapper:Profile
    {
        public MessageDetailMapper()
        {
            CreateMap<MessagesDetail, CreateMessageDetailDto>().ReverseMap();
            CreateMap<UpdateMessageDetailDto, MessagesDetail > ().ReverseMap();
        }
    }
}
