using AutoMapper;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Sending.Mappings
{
    public class MessageBatchMapper:Profile
    {
        public MessageBatchMapper()
        {
            CreateMap<Entities.MessageBatch, CreateMessageBatchDto>().ReverseMap();
        }
    }
}
