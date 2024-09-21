using AutoMapper;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;
using Entities = SmsHub.Domain.Features.Entities;


namespace SmsHub.Application.Features.Consumer.Mappings
{
    public class ConsumerSafeIpMapper:Profile
    {
        public ConsumerSafeIpMapper()//todo: introduction to startup
        {
            CreateMap<Entities.ConsumerSafeIp, CreateConsumerSafeIpDto>().ReverseMap();
        }
    }
}
