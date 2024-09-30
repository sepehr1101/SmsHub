using AutoMapper;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Line.Mappings
{
    public class ProviderMapper:Profile
    {
        public ProviderMapper()
        {
            CreateMap<Provider, CreateProviderDto>().ReverseMap();
            CreateMap<UpdateProviderDto,Provider>().ReverseMap();
        }
    }
}
