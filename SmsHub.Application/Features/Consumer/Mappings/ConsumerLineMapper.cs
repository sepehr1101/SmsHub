using AutoMapper;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Consumer.Mappings
{
    public class ConsumerLineMapper : Profile
    {
        public ConsumerLineMapper()
        {
            CreateMap<Entities.ConsumerLine, CreateConsumerLineDto>().ReverseMap();
        }
    }
}
