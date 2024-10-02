using AutoMapper;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Config.Mappings
{
    public class CcSendMapper:Profile
    {
        public CcSendMapper()
        {
            CreateMap<CreateCcSendDto,CcSend >().ReverseMap();
            CreateMap<UpdateCcSendDto, CcSend>().ReverseMap();
            CreateMap<GetCcSendDto, CcSend>().ReverseMap();
        }
    }
}
