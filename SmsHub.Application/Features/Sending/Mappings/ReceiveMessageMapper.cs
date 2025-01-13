using AutoMapper;
using SmsHub.Domain.Features.Receiving.Entities;
using SmsHub.Domain.Features.Receiving.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Sending.Mappings
{
    public class ReceiveMessageMapper:Profile
    {
        public ReceiveMessageMapper()
        {
            CreateMap<CreateReceiveDto, Receive>().ReverseMap();
        }
    }
}
