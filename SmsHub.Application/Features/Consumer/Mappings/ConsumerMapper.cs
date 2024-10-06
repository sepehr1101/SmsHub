using AutoMapper;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Consumer.Mappings
{
    public class ConsumerMapper:Profile
    {
        public ConsumerMapper()
        {
            CreateMap<Entities.Consumer, CreateConsumerDto>().ReverseMap();
            CreateMap<UpdateConsumerDto,Entities.Consumer>().ReverseMap();
        }
    }
}
