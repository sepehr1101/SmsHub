using AutoMapper;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;
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
