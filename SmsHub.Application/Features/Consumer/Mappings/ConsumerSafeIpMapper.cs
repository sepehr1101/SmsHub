using AutoMapper;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Update;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Consumer.Mappings
{
    public class ConsumerSafeIpMapper:Profile
    {
        public ConsumerSafeIpMapper()
        {
            CreateMap<ConsumerSafeIp, CreateConsumerSafeIpDto>().ReverseMap();
            CreateMap<UpdateConsumerSafeIpDto,ConsumerSafeIp>().ReverseMap();
        }
    }
}
