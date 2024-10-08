using AutoMapper;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Queries;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Consumer.Mappings
{
    public class ConsumerSafeIpMapper:Profile
    {
        public ConsumerSafeIpMapper()
        {
            CreateMap< CreateConsumerSafeIpDto, ConsumerSafeIp>().ReverseMap();
            CreateMap<UpdateConsumerSafeIpDto,ConsumerSafeIp>().ReverseMap();
            CreateMap<GetConsumerSafaIpDto,ConsumerSafeIp>().ReverseMap();
        }
    }
}
