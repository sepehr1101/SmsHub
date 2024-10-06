using AutoMapper;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Queries;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Update;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Consumer.Mappings
{
    public class ConsumerLineMapper : Profile
    {
        public ConsumerLineMapper()
        {
            CreateMap< CreateConsumerLineDto, ConsumerLine>().ReverseMap();
            CreateMap<UpdateConsumerLineDto, ConsumerLine>().ReverseMap();
            CreateMap<GetConsumerLineDto, ConsumerLine>().ReverseMap();
        }
    }
}
