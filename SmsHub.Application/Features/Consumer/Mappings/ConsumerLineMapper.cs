using AutoMapper;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Consumer.Mappings
{
    public class ConsumerLineMapper : Profile
    {
        public ConsumerLineMapper()
        {//todo: introduction to startup
            CreateMap<Entities.ConsumerLine, CreateConsumerLineDto>().ReverseMap();
        }
    }
}
