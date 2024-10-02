using AutoMapper;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Sending.Mappings
{
    public class MessageBatchMapper:Profile
    {
        public MessageBatchMapper()
        {
            CreateMap<MessageBatch, CreateMessageBatchDto>().ReverseMap();
            CreateMap<UpdateMessageBatchDto, MessageBatch > ().ReverseMap();
        }
    }
}
