using AutoMapper;
using SmsHub.Domain.Features.Sending.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Sending.Mappings
{
    public class ReceiveMessageMapper:Profile
    {
        public ReceiveMessageMapper()
        {
            CreateMap<CreateReceiveDto, Received>().ReverseMap();
        }
    }
}
