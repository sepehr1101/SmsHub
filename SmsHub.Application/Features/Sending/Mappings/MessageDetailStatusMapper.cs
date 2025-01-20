using AutoMapper;
using SmsHub.Domain.Features.Sending.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Sending.Mappings
{
   public class MessageDetailStatusMapper:Profile
    {
        public MessageDetailStatusMapper()
        {
            CreateMap<CreateMessageDetailStatusDto, MessageDetailStatus>().ReverseMap();
            CreateMap<DeleteMessageDetailStatusDto, MessageDetailStatus>().ReverseMap();
            CreateMap<UpdateMessageDetailStatusDto, MessageDetailStatus>().ReverseMap();
        }
    }
}
