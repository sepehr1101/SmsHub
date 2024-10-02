using AutoMapper;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Config.Mappings
{
    public class CcSendMapper:Profile
    {
        public CcSendMapper()
        {
            CreateMap<CcSend, CreateCcSendDto>().ReverseMap();
            CreateMap<UpdateCcSendDto, CcSend>().ReverseMap();
        }
    }
}
