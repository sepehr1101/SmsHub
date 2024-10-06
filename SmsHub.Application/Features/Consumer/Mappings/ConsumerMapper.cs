using AutoMapper;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Queries;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Consumer.Mappings
{
    public class ConsumerMapper:Profile
    {
        public ConsumerMapper()
        {
            CreateMap< CreateConsumerDto, Entities.Consumer>().ReverseMap();
            CreateMap<UpdateConsumerDto,Entities.Consumer>().ReverseMap();
            CreateMap<GetConsumerDto,Entities.Consumer>().ReverseMap();
        }
    }
}
