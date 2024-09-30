using AutoMapper;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Config.Mappings
{
    public class CcSendMapper:Profile
    {
        public CcSendMapper()
        {
            CreateMap<Entities.CcSend, CreateCcSendDto>().ReverseMap();
        }
    }
}
