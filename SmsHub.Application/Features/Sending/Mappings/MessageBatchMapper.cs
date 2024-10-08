using AutoMapper;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Sending.Mappings
{
    public class MessageBatchMapper:Profile
    {
        public MessageBatchMapper()
        {
            CreateMap< CreateMessageBatchDto, MessageBatch>().ReverseMap();
            CreateMap<UpdateMessageBatchDto, MessageBatch > ().ReverseMap();
            CreateMap<GetMessageBatchDto, MessageBatch > ().ReverseMap();
        }
    }
}
