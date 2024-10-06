using AutoMapper;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Update;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Consumer.Mappings
{
    public class ConsumerLineMapper : Profile
    {
        public ConsumerLineMapper()
        {
            CreateMap<ConsumerLine, CreateConsumerLineDto>().ReverseMap();
            CreateMap<UpdateConsumerLineDto, ConsumerLine>().ReverseMap();
        }
    }
}
