using AutoMapper;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Sending.Mappings
{
    public class MessageDetailMapper:Profile
    {
        public MessageDetailMapper()
        {
            CreateMap< CreateMessageDetailDto, MessagesDetail>().ReverseMap();
            CreateMap<UpdateMessageDetailDto, MessagesDetail > ().ReverseMap();
            CreateMap<GetMessageDetailDto, MessagesDetail > ().ReverseMap();
        }
    }
}
